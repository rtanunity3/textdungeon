using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using textdungeon.Screen;

namespace textdungeon.Play
{
    internal class Battle
    {
        private List<Monster> Monsters;
        //선택한 던전의 번호를 알아오는 변수
        int dungeonnum = 0;
        public List<Monster> Enemies = new List<Monster>();
        public string BattleAttackEndMessage = "";
        public string BattleEnemiesAttackMessage = "";
        /// <summary> 적들의 공격순서 리스트 </summary>
        public List<int> BattleEnamiesAttackList = new List<int>();
        /// <summary> 배틀입장시 플레이어 체력 </summary>
        public int PlayerPastHealth = 0;

        //유저가 선택한 던전번호를 알아오는 void함수
        public void SelectDungeon(int selectdungeon)
        {
            dungeonnum = selectdungeon;
        }

        public void NewBattle(int enemieNum)
        {
            Enemies.Clear();
            if (dungeonnum == 1)
            {
                for (int i = 0; i < enemieNum; i++)
                {
                    List<Monster> Goblines = new List<Monster>()
                    {
                        new Kobold(new Random().Next(1,4)),
                        new Goblin(new Random().Next(1,4)),
                        new Hobgoblin(new Random().Next(1,4)),
                    };
                    Monster monster = Goblines[new Random().Next(0, Goblines.Count)];
                    Enemies.Add(monster);
                }
            }
            else if (dungeonnum == 2)
            {
                for (int i = 0; i < enemieNum; i++)
                {
                    List<Monster> Undeads = new List<Monster>()
                    {
                        new Zombie(new Random().Next(1,4)),
                        new Ghost(new Random().Next(1,4)),
                        new Ghoul(new Random().Next(1,4)),
                        new Banshee(new Random().Next(1,4)),
                        new Skeleton(new Random().Next(1,4))
                    };
                    Monster monster = Undeads[new Random().Next(0, Undeads.Count)];
                    Enemies.Add(monster);
                }
            }
            else if (dungeonnum == 3)
            {
                for (int i = 0; i < enemieNum; i++)
                {
                    List<Monster> Spirit = new List<Monster>()
                    {
                        new Undine(new Random().Next(1,4)),
                        new Sylph(new Random().Next(1,4)),
                        new Salamandra(new Random().Next(1,4)),
                        new Gnome(new Random().Next(1,4))
                    };
                    Monster monster = Spirit[new Random().Next(0, Spirit.Count)];
                    Enemies.Add(monster);
                }
            }
            else if (dungeonnum == 4)
            {
                for (int i = 0; i < enemieNum; i++)
                {
                    List<Monster> Unicon = new List<Monster>()
                    {
                        new Unicon(1)
                    };
                    Monster monster = Unicon[new Random().Next(0, Unicon.Count)];
                    Enemies.Add(monster);
                }
            }
            else if (dungeonnum == 5)
            {
                for (int i = 0; i < enemieNum; i++)
                {
                    List<Monster> Titan = new List<Monster>()
                    {
                        new Titan(1)
                    };
                    Monster monster = Titan[new Random().Next(0, Titan.Count)];
                    Enemies.Add(monster);
                }
            }
            else if (dungeonnum == 6)
            {
                for (int i = 0; i < enemieNum; i++)
                {
                    List<Monster> Dragon = new List<Monster>()
                    {
                        new Dragon(1)
                    };
                    Monster monster = Dragon[new Random().Next(0, Dragon.Count)];
                    Enemies.Add(monster);
                }
            }
        }

        public void GetBattleReward(Player player)
        {
            var playerGiveExp = 0;
            var playerGiveGold = 0;
            for (int i = 0; i < Enemies.Count; i++)
            {
                playerGiveExp += Enemies[i].GiveExp;
                playerGiveGold += Enemies[i].Gold;
                Enemies[i].SetDropTable(player.Job);
                player.AddItem(Enemies[i].GetItemReward());
            }
            player.Gold += playerGiveGold;
            player.AddExp(playerGiveExp);

            //몬스터를 처치한다음 획득한 경험치를 표시
            Console.WriteLine($"획득경험치{playerGiveExp}");
        }

        // 적 목록 출력
        public void PrintEnemies(bool writeNum)
        {
            for (int i = 0; i < Enemies.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(writeNum ? $"[{i + 1}] " : " ");
                Console.ResetColor();
                if (Enemies[i].IsDead) Printing.HighlightText(Enemies[i].ToStringEnemie, ConsoleColor.DarkGray);
                else Console.Write(Enemies[i].ToStringEnemie);
                Console.WriteLine();
            }
        }

        public void PrintPlayer(Player player)
        {
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({EnumHandler.GetjobKr(player.Job)})");
            Console.Write("HP : ");
            Printing.HighlightText($"{player.Health,3}/{player.MaxHealth}\n", ConsoleColor.Red);
            Console.Write("MP : ");
            Printing.HighlightText($"{player.Mana,3}/{player.MaxMana}\n", ConsoleColor.Blue);
        }

        /// <summary>
        /// 플레이어가 선택한 몬스터에게 대미지를 준다.
        /// </summary>
        public bool PlayerAttackSelect(Player player, int select, int dmg, bool isSkill = false)
        {
            if (!(select > 0 && select <= Enemies.Count)) return false;
            Monster monster = Enemies[select - 1];
            if (!monster.IsDead) // 공격가능한 대상 선택함
            {
                string msg = "";
                msg += $"{player.Name} 의 공격!\r\n";
                // 적의 회피확률 10%(스킬 제외)
                if (!isSkill && new Random().Next(0, 101) < 10)
                {
                    msg += $"{monster.ToStringName} 을(를) 공격했지만 아무일도 일어나지 않았습니다.";
                    BattleAttackEndMessage = msg;
                    return true;
                }

                // 치명타 확률 15%, 데미지 160% 로 구현하기
                bool IsCritical = false;
                if (new Random().Next(0, 101) < 15)
                {
                    IsCritical = true;
                    dmg = Convert.ToInt32(dmg * 1.6);
                }

                // 데미지 오차범위 10%(소수점 올림)
                int dmgRange = Convert.ToInt32(Math.Ceiling(dmg * 0.1));
                int finalDmg = dmg + new Random().Next(-dmgRange, dmgRange + 1);

                int hp = monster.Health;
                monster.Health -= finalDmg;
                msg += $"{monster.ToStringName} 을(를) 맞췄습니다. [데미지 : {finalDmg}]{(IsCritical ? " - 치명타 공격!!" : "")}\r\n";
                msg += "\r\n";
                msg += $"{monster.ToStringName}\r\n";
                msg += $"HP {hp} -> {(monster.IsDead ? "Dead" : $"HP {monster.Health}")}\r\n";

                BattleAttackEndMessage = msg;
                return true;
            }
            return false;
        }

        public bool PlayerSkillAttackSelect(Player player, int skillNo, int select = 0)
        {
            if (player.Skill[skillNo].SkillType == SkillType.Single)
            {
                Monster monster = Enemies[select - 1];
                if (!monster.IsDead) // 공격가능한 대상 선택함
                {
                    string msg = "";
                    msg += $"{player.Name} 의 {player.Skill[skillNo].Name}!\r\n";

                    int skillDamage = (int)(player.NormalDamage * player.Skill[skillNo].DamagePercentage);

                    // 치명타 확률 15%, 데미지 160% 로 구현하기
                    bool IsCritical = false;
                    if (new Random().Next(0, 101) < 15)
                    {
                        IsCritical = true;
                        skillDamage = Convert.ToInt32(skillDamage * 1.6);
                    }

                    int dmgRange = Convert.ToInt32(Math.Ceiling(skillDamage * 0.1));
                    int finalDmg = skillDamage + new Random().Next(-dmgRange, dmgRange + 1);

                    int hp = monster.Health;
                    monster.Health -= finalDmg;
                    player.Mana -= player.Skill[skillNo].Mana;

                    msg += $"{monster.ToStringName} 을(를) 맞췄습니다. [데미지 : {finalDmg}]{(IsCritical ? " - 치명타 공격!!" : "")}\r\n";
                    msg += "\r\n";
                    msg += $"{monster.ToStringName}\r\n";
                    msg += $"HP {hp} -> {(monster.IsDead ? "Dead" : $"HP {monster.Health}")}\r\n";
                    BattleAttackEndMessage = msg;
                    return true;
                }

            }
            else if (player.Skill[skillNo].SkillType == SkillType.Multiple)
            {
                int skillDamage = (int)(player.NormalDamage * player.Skill[skillNo].DamagePercentage);

                // 전체공격
                StringBuilder msg = new StringBuilder();
                msg.Append($"{player.Name} 의 {player.Skill[skillNo].Name} 전체공격!\n");

                for (int i = 0; i < Enemies.Count; i++)
                {
                    if (Enemies[i].IsDead)
                    {
                        // 죽은몹
                        continue;
                    }

                    // 치명타 확률 15%, 데미지 160% 로 구현하기
                    bool IsCritical = false;
                    if (new Random().Next(0, 101) < 15)
                    {
                        IsCritical = true;
                        skillDamage = Convert.ToInt32(skillDamage * 1.6);
                    }

                    int dmgRange = Convert.ToInt32(Math.Ceiling(skillDamage * 0.1));
                    int finalDmg = skillDamage + new Random().Next(-dmgRange, dmgRange + 1);

                    int hp = Enemies[i].Health;
                    Enemies[i].Health -= finalDmg;

                    msg.Append($"{Enemies[i].ToStringName}  [데미지 : {finalDmg}]{(IsCritical ? " - 치명타 공격!!" : "")}\n");
                    msg.Append($"  HP {hp} -> {(Enemies[i].IsDead ? "Dead" : $"HP {Enemies[i].Health}")}\n");
                }
                BattleAttackEndMessage = msg.ToString();
                player.Mana -= player.Skill[skillNo].Mana;
                return true;

            }
            else if (player.Skill[skillNo].SkillType == SkillType.Self)
            {
                // 자힐
                int skillDamage = (int)(player.NormalDamage * player.Skill[skillNo].DamagePercentage);

                int dmgRange = Convert.ToInt32(Math.Ceiling(skillDamage * 0.1));
                int finalDmg = skillDamage + new Random().Next(-dmgRange, dmgRange + 1);

                int hp = player.Health;
                player.Health = Math.Max(Math.Min((player.Health + finalDmg), player.MaxHealth), 0);
                player.Mana -= player.Skill[skillNo].Mana;

                StringBuilder msg = new StringBuilder();
                msg.Append($"{player.Name} 의 {player.Skill[skillNo].Name} 사용!\n");
                msg.Append($"[치료량 : {finalDmg}] HP {hp} -> {player.Health}\n");
                BattleAttackEndMessage = msg.ToString();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 공격차례가 남은 몬스터가 플레이어에게 대미지를 준다.
        /// </summary>
        public GameState EnemiesAttack(Player player)
        {
            int len = BattleEnamiesAttackList.Count;
            if (len == 0) return GameState.BattleGround;

            int uniqueID = BattleEnamiesAttackList[len - 1];
            BattleEnamiesAttackList.RemoveAt(len - 1);

            Monster monster = Enemies.Find(e => e.UniqueID == uniqueID);
            int dmg = monster.AttPow - (player.DefPow + player.ItemDefPow);
            if (dmg < 0) dmg = 0;

            int hp = player.Health;
            player.Health -= dmg;
            if (player.Health < 0) player.Health = 0;

            string msg = "";
            msg += $"{monster.ToStringName} 의 공격!\r\n";
            msg += $"{player.Name} 을(를) 맞췄습니다. [데미지: {dmg}]\r\n";
            msg += "\r\n";
            msg += $"Lv.{player.Level} {player.Name}\r\n";
            msg += $"HP {hp} -> {player.Health}\r\n";
            BattleEnemiesAttackMessage = msg;

            if (player.Health <= 0) return GameState.BattlePlayerDead;
            else return GameState.BattleEnemiesAttack;
        }

        public void DisplayBattle(bool writeNum, GameState gameState, Player player, int skillNo = 0)
        {
            Console.Clear();
            Printing.HighlightText("Battle!!", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine();
            switch (gameState)
            {
                case GameState.BattleGround:
                    PrintEnemies(writeNum);
                    Console.WriteLine();
                    PrintPlayer(player);
                    Console.WriteLine();
                    Printing.SelectWriteLine(1, "공격");
                    Printing.SelectWriteLine(2, "스킬");
                    Printing.SelectWriteLine(0, "도망");
                    Console.WriteLine();
                    Printing.HighlightText("플레이어 턴", ConsoleColor.Green);
                    break;
                case GameState.BattleAttack:
                    PrintEnemies(writeNum);
                    Console.WriteLine();
                    PrintPlayer(player);
                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "공격취소");
                    Console.WriteLine();
                    Printing.HighlightText("플레이어 턴", ConsoleColor.Green);
                    break;
                case GameState.BattleAttackEnd:
                    Console.WriteLine(BattleAttackEndMessage);
                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "다음");
                    Console.WriteLine();
                    Printing.HighlightText("플레이어 턴", ConsoleColor.Green);
                    break;
                case GameState.BattleEnemiesAttack:
                    Console.WriteLine(BattleEnemiesAttackMessage);
                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "다음");
                    Console.WriteLine();
                    Printing.HighlightText("적 턴", ConsoleColor.Green);
                    break;
                case GameState.BattlePlayerWin:
                    Console.WriteLine("Victory");
                    Console.WriteLine();
                    Console.WriteLine($"던전에서 몬스터 {Enemies.Count}마리를 잡았습니다.");
                    Console.WriteLine();
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    GetBattleReward(player);
                    Console.WriteLine($"HP {PlayerPastHealth} -> {player.Health}");
                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "다음");
                    break;
                case GameState.BattlePlayerDead:
                    Console.WriteLine("You Lose");
                    Console.WriteLine();
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {PlayerPastHealth} -> {player.Health}");
                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "다음");
                    break;
                case GameState.BattleSkillList:
                    PrintEnemies(writeNum);
                    Console.WriteLine();
                    PrintPlayer(player);
                    Console.WriteLine();
                    player.ShowSkillList();
                    Printing.SelectWriteLine(0, "취소");
                    Console.WriteLine();
                    Printing.HighlightText("플레이어 턴", ConsoleColor.Green);
                    break;

                case GameState.BattleSkillAttack:
                    PrintEnemies(writeNum);
                    Console.WriteLine();
                    PrintPlayer(player);
                    Console.WriteLine();
                    player.ShowSkillList(skillNo);
                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "취소");
                    Console.WriteLine();
                    Printing.HighlightText("플레이어 턴", ConsoleColor.Green);
                    break;
            }
        }
    }
}
