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
            new Monster("미니언", 15, 10, 100, 2, 0, 0),
            new Monster("대포미니언", 25, 15, 100, 5, 1, 0),
            new Monster("공허충", 10, 7, 100, 3, 2, 0)
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
            Console.WriteLine($"Lv.{player.Level} {player.Name} (전사)");
            Console.WriteLine($"HP {player.Health}/100");
        }

        /// <summary>
        /// 플레이어가 선택한 몬스터에게 대미지를 준다.
        /// </summary>
        public bool PlayerAttackSelect(Player player,int select, int dmg, bool isSkill = false)
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
                msg += $"HP {hp} -> {(monster.IsDead ? "Daed" : $"HP {monster.Health}")}\r\n";
                BattleAttackEndMessage = msg;
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

            int dmg = monster.AttPow - player.DefPow + player.ItemDefPow;
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
