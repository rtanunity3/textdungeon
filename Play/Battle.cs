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
        private List<Monster> Monsters = new List<Monster>()
        {
            new Monster("미니언", 15, 3, 50, 2, 0, 0),
            new Monster("대포미니언", 25, 5, 100, 5, 1, 0),
            new Monster("공허충", 10, 2, 50, 3, 2, 0)
        };
        public List<Monster> Enemies = new List<Monster>();
        public string BattleAttackEndMessage = "";
        public string BattleEnemiesAttackMessage = "";
        /// <summary> 적들의 공격순서 리스트 </summary>
        public List<int> BattleEnamiesAttackList = new List<int>();
        /// <summary> 배틀입장시 플레이어 체력 </summary>
        public int PlayerPastHealth = 0;

        public void NewBattle(int enemieNum)
        {
            Enemies.Clear();
            for (int i = 0; i < enemieNum; i++)
            {
                Monster monster = Monsters[new Random().Next(0, Monsters.Count)];
                Enemies.Add(new Monster(monster.Name, monster.Health, monster.AttPow, monster.Gold, monster.Level, monster.ID, i));
            }
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
            Console.WriteLine($"Lv.{player.Level} {player.Name} {EnumHandler.GetjobKr(player.Job)}");
            Console.WriteLine($"HP {player.Health}/{player.MaxHealth}");
        }

        public bool PlayerAttackSelect(Player player, int select)
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

        public bool PlayerSkillAttackSelect(Player player, int skillNo, int select = 0)
        {
            if (player.Skill[skillNo].SkillType == SkillType.Single) { 
                Monster monster = Enemies[select - 1];
                if (!monster.IsDead) // 공격가능한 대상 선택함
                {
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
            int dmg = monster.AttPow - player.DefPow + player.ItemDefPow;
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
                    break;
                case GameState.BattleAttack:
                    PrintEnemies(writeNum);
                    Console.WriteLine();
                    PrintPlayer(player);
                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "공격취소");
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
                    PrintEnemies(writeNum);
                    Console.WriteLine();
                    PrintPlayer(player);
                    Console.WriteLine();
                    player.ShowSkillList();
                    Printing.SelectWriteLine(0, "취소");
                    break;

                case GameState.BattleSkillAttack:
                    PrintEnemies(writeNum);
                    Console.WriteLine();
                    PrintPlayer(player);
                    Console.WriteLine();
                    player.ShowSkillList(skillNo);
                    Printing.SelectWriteLine(0, "취소");
                    break;
            }
        }
    }
}
