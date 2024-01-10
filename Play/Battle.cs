using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textdungeon.Screen;

namespace textdungeon.Play
{
    internal class Battle
    {
        private List<Monster> Monsters = new List<Monster>()
        {
            new Monster("미니언", 15, 10, 100, 2),
            new Monster("대포미니언", 25, 15, 100, 5),
            new Monster("공허충", 10, 5, 100, 3)
        };
        public List<Monster> Enemies = new List<Monster>();

        public Battle()
        {
            for (int i = 0;  i < 3; i++) 
            {
                Monster monster = Monsters[new Random().Next(0, Monsters.Count)];
                Enemies.Add(new Monster(monster.Name, monster.Health, monster.AttPow, monster.Gold, monster.Level));
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

        public void DisplayBattle(bool writeNum, GameState gameState, Player player)
        {
            Console.Clear();
            Printing.HighlightText("Battle!!", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine();
            PrintEnemies(writeNum);
            Console.WriteLine();
            PrintPlayer(player);
            Console.WriteLine();
            switch (gameState)
            {
                case GameState.BattleGround:
                    Console.WriteLine("0. 공격");
                    break;
                case GameState.BattleAttack:
                    Console.WriteLine("0. 공격취소");
                    Console.WriteLine();
                    Console.WriteLine("대상을 선택해주세요.");
                    Console.Write(">> ");
                    break;
                case GameState.BattleAttackEnd:
                    Console.WriteLine("0. 다음");
                    Console.Write(">> ");
                    break;
                /*
Battle!!

Chad 의 공격!
Lv.3 공허충 을(를) 맞췄습니다. [데미지 : 10]

Lv.3 공허충
HP 10 -> Dead

0. 다음

>>
                */
                case GameState.BattleSkillList:
                    Console.WriteLine("스킬목록 구현필요");
                    break;
                case GameState.BattleSkillAttack:
                    Console.WriteLine("스킬공격 구현필요");
                    break;
            }
            Console.WriteLine();
        }
    }
}
