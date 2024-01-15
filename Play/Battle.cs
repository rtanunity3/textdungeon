using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using textdungeon.Screen;

namespace textdungeon.Play
{
    internal class Battle
    {
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
                    Enemies.Add(new Monster(monster.Name, monster.Health, monster.AttPow, monster.Gold, monster.Level, monster.ID, i, monster.GiveExp));
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
                    Enemies.Add(new Monster(monster.Name, monster.Health, monster.AttPow, monster.Gold, monster.Level, monster.ID, i, monster.GiveExp));
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
                    Enemies.Add(new Monster(monster.Name, monster.Health, monster.AttPow, monster.Gold, monster.Level, monster.ID, i, monster.GiveExp));
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
                    Enemies.Add(new Monster(monster.Name, monster.Health, monster.AttPow, monster.Gold, monster.Level, monster.ID, i, monster.GiveExp));
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
                    Enemies.Add(new Monster(monster.Name, monster.Health, monster.AttPow, monster.Gold, monster.Level, monster.ID, i, monster.GiveExp));
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
                    Enemies.Add(new Monster(monster.Name, monster.Health, monster.AttPow, monster.Gold, monster.Level, monster.ID, i, monster.GiveExp));
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
                Console.Write(writeNum ? $"[{i + 1}]" : "");
                if (Enemies[i].IsDead) Printing.HighlightText(Enemies[i].ToStringEnemie, ConsoleColor.DarkGray); 
                else Console.Write(Enemies[i].ToStringEnemie);
                Console.WriteLine();
            }
        }

        public void PrintPlayer(Player player)
        {
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} (전사)");
            Console.WriteLine($"HP {player.Health}/100");
        }

        public bool PlayerAttackSelect(Player player,int select)
        {
            Monster monster = Enemies[select - 1];
            if (!monster.IsDead) // 공격가능한 대상 선택함
            {
                // 데미지 오차범위 10%(오차 0.5 -> 1로 소수점 올림)
                int dmgRange = Convert.ToInt32(Math.Ceiling(player.AttPow + player.ItemAttPow * 0.1));
                int dmg = player.AttPow + player.ItemAttPow + new Random().Next(-dmgRange, dmgRange + 1);
                int hp = monster.Health;
                monster.Health -= dmg;

                string msg = @$"{player.Name} 의 공격!
{monster.ToStringName} 을(를) 맞췄습니다. [데미지 : {dmg}]

{monster.ToStringName}
HP {hp} -> {(monster.IsDead ? "Daed" : $"HP {monster.Health}")}";
                BattleAttackEndMessage = msg;
                return true;
            }
            return false;
        }

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
            string msg = @$"{monster.ToStringName} 의 공격!
{player.Name} 을(를) 맞췄습니다. [데미지: {dmg}]

Lv.{player.Level} {player.Name}
HP {hp} -> {player.Health}
";
            BattleEnemiesAttackMessage = msg;
            if (player.Health <= 0) return GameState.BattlePlayerDead;
            else return GameState.BattleEnemiesAttack;
        }

        public void DisplayBattle(bool writeNum, GameState gameState, Player player)
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
                    Console.WriteLine("0. 공격");
                    break;
                case GameState.BattleAttack:
                    PrintEnemies(writeNum);
                    Console.WriteLine();
                    PrintPlayer(player);
                    Console.WriteLine();
                    Console.WriteLine("0. 공격취소");
                    break;
                case GameState.BattleAttackEnd:
                    Console.WriteLine(BattleAttackEndMessage);
                    Console.WriteLine();
                    Console.WriteLine("0. 다음");
                    break;
                case GameState.BattleEnemiesAttack:
                    Console.WriteLine(BattleEnemiesAttackMessage);
                    Console.WriteLine();
                    Console.WriteLine("0. 다음");
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
                    Console.WriteLine("0. 다음");
                    break;
                case GameState.BattlePlayerDead:
                    Console.WriteLine("You Lose");
                    Console.WriteLine();
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.WriteLine($"HP {PlayerPastHealth} -> {player.Health}");
                    Console.WriteLine();
                    Console.WriteLine("0. 다음");
                    break;
                case GameState.BattleSkillList:
                    Console.WriteLine("스킬목록 구현필요");
                    break;
                case GameState.BattleSkillAttack:
                    Console.WriteLine("스킬공격 구현필요");
                    break;
            }
        }
    }
}
