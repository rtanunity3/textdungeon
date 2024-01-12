using System;
using System.Collections.Generic;
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
            new Monster("미니언", 15, 10, 100, 2, 0, 0),
            new Monster("대포미니언", 25, 15, 100, 5, 1, 0),
            new Monster("공허충", 10, 5, 100, 3, 2, 0)
        };
        public List<Monster> Enemies = new List<Monster>();
        public string BattleAttackEndMessage = "";
        public string BattleEnemiesAttackMessage = "";
        public List<int> BattleEnamiesAttackList = new List<int>();

        public Battle()
        {
            for (int i = 0;  i < 3; i++) 
            {
                Monster monster = Monsters[new Random().Next(0, Monsters.Count)];
                Enemies.Add(new Monster(monster.Name, monster.Health, monster.AttPow, monster.Gold, monster.Level, monster.ID, i));
            }
        }

        public void PrintEnemies(bool writeNum)
        {
            for (int i = 0; i < Enemies.Count; i++) Console.WriteLine($"{(writeNum ? $"[{i + 1}]" : "" )}" + Enemies[i].ToStringEnemie);
        }

        public void PrintPlayer(Player player)
        {
            Console.WriteLine("[내정보]");
            Console.WriteLine($"Lv.{player.Level} {player.Name} (전사)");
            Console.WriteLine($"HP {player.Health}/100");
        }
        public bool PlayerAttackAt(Player player,int select)
        {
            Monster monster = Enemies[select - 1];
            if (!monster.IsDead) // 공격가능한 대상 선택함
            {
                int dmg = player.AttPow;
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
            int dmg = monster.AttPow;
            int hp = player.Health;
            player.Health -= dmg;
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
