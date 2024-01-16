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
        Random rand = new Random();
        int dunlev = 0;
        //선택한 던전의 번호를 알아오는 변수
        int dungeonnum = 0;
        //선택한 던전의 난이도를 알아오는 변수
        int dungeonlevel = 0;
        //선택한 던전의 타입을 알아오는 변수
        int dungeontype = 0;
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

        //유저가 선택한 던전레벨을 알아호는 void함수
        public void SelectDungeonLevel(int selectdungeonlevel)
        {
            dungeonlevel = selectdungeonlevel;
        }

        //유저가 선택한 던전의 타입을 알아오는 void함수
        public void SelectDungeonType(int selectdungeontype)
        {
            dungeontype = selectdungeontype;
        }

        public void NewBattle(int enemieNum)
        {
            Enemies.Clear();
            dunlev = rand.Next(1, 11);
            bool bossCheck = false;
            if (dungeonnum == 1)
            {
                if (dunlev < 4)
                {
                    List<Monster> Goblines = new List<Monster>()
                        {
                            new Kobold(new Random().Next(1,dungeonlevel)),
                        };
                    for (int i = 0; i < enemieNum; i++)
                    {
                        Monster monster = Goblines[new Random().Next(0, Goblines.Count)];
                        Enemies.Add((Monster)monster.ShallowCopy());
                    }
                }
                else if (dunlev >= 4 && dunlev < 8)
                {
                    List<Monster> Goblines = new List<Monster>()
                        {
                            new Kobold(new Random().Next(1,dungeonlevel)),
                            new Goblin(new Random().Next(1,dungeonlevel)),
                        };
                    for (int i = 0; i < enemieNum; i++)
                    {
                        Monster monster = Goblines[new Random().Next(0, Goblines.Count)];
                        Enemies.Add((Monster)monster.ShallowCopy());
                    }
                }
                else
                {
                    List<Monster> Goblines = new List<Monster>()
                        {
                            new Kobold(new Random().Next(1,dungeonlevel)),
                            new Goblin(new Random().Next(1,dungeonlevel)),
                            new Hobgoblin(new Random().Next(5,dungeonlevel + 5)),
                        };
                    for (int i = 0; i < enemieNum; i++)
                    {
                        int check;
                        if (bossCheck)
                        {
                            check = new Random().Next(0, Goblines.Count - 1);
                        }
                        else
                        {
                            check = new Random().Next(0, Goblines.Count);
                            if (check == 2)
                            {
                                bossCheck = true;
                            }
                        }
                        Monster monster = Goblines[check];
                        Enemies.Add((Monster)monster.ShallowCopy());
                    }
                }
            }
            else if (dungeonnum == 2)
            {
                if (dunlev < 4)
                {
                    List<Monster> Undeads = new List<Monster>()
                    {
                        new Zombie(new Random().Next(1,dungeonlevel)),
                        new Ghost(new Random().Next(1,dungeonlevel)),
                    };
                    for (int i = 0; i < enemieNum; i++)
                    {
                        Monster monster = Undeads[new Random().Next(0, Undeads.Count)];
                        Enemies.Add((Monster)monster.ShallowCopy());
                    }
                }
                else if (dunlev >= 4 && dunlev < 8)
                {
                    List<Monster> Undeads = new List<Monster>()
                    {
                        new Zombie(new Random().Next(1,dungeonlevel)),
                        new Ghost(new Random().Next(1,dungeonlevel)),
                        new Ghoul(new Random().Next(1,dungeonlevel)),
                        new Skeleton(new Random().Next(1,dungeonlevel))
                    };
                    for (int i = 0; i < enemieNum; i++)
                    {
                        Monster monster = Undeads[new Random().Next(0, Undeads.Count)];
                        Enemies.Add((Monster)monster.ShallowCopy());
                    }
                }
                else
                {
                    List<Monster> Undeads = new List<Monster>()
                    {
                        new Zombie(new Random().Next(1,dungeonlevel)),
                        new Ghost(new Random().Next(1,dungeonlevel)),
                        new Ghoul(new Random().Next(1,dungeonlevel)),
                        new Banshee(new Random().Next(5,dungeonlevel + 5)),
                        new Skeleton(new Random().Next(1,dungeonlevel))
                    };
                    for(int i = 0; i < enemieNum; i++)
                    {
                        int check;
                        if (bossCheck)
                        {
                            check = new Random().Next(0, Undeads.Count - 1);
                        }
                        else
                        {
                            check = new Random().Next(0, Undeads.Count);
                            if (check == 4)
                            {
                                bossCheck = true;
                            }
                        }
                        Monster monster = Undeads[check];
                        Enemies.Add((Monster)monster.ShallowCopy());
                    }
                }
            }
            else if (dungeonnum == 3)
            {
                if (dungeontype == 1)
                {
                    if (dunlev < 8)
                    {
                        List<Monster> Spirit = new List<Monster>()
                            {
                                new Undine(new Random().Next(1,dungeonlevel)),
                            };
                        for (int i = 0; i < enemieNum; i++)
                        {
                            Monster monster = Spirit[new Random().Next(0, Spirit.Count)];
                            Enemies.Add((Monster)monster.ShallowCopy());
                        }
                    }
                    else
                    {
                        List<Monster> Spirit = new List<Monster>()
                            {
                                new Undine(new Random().Next(1,dungeonlevel)),
                                new Elquiness(new Random().Next(5,dungeonlevel + 5)),
                            };
                        for (int i = 0; i < enemieNum; i++)
                        {
                            int check;
                            if (bossCheck)
                            {
                                check = new Random().Next(0, Spirit.Count - 1);
                            }
                            else
                            {
                                check = new Random().Next(0, Spirit.Count);
                                if (check == 1)
                                {
                                    bossCheck = true;
                                }
                            }
                            Monster monster = Spirit[check];
                            Enemies.Add((Monster)monster.ShallowCopy());
                        }
                    }
                }
                else if (dungeontype == 2)
                {
                    if (dunlev < 8)
                    {
                        List<Monster> Spirit = new List<Monster>()
                            {
                                new Sylph(new Random().Next(1, dungeonlevel)),
                            };
                        for (int i = 0; i < enemieNum; i++)
                        {
                            Monster monster = Spirit[new Random().Next(0, Spirit.Count)];
                            Enemies.Add((Monster)monster.ShallowCopy());
                        }
                    }
                    else
                    {
                        List<Monster> Spirit = new List<Monster>()
                            {
                                new Sylph(new Random().Next(1, dungeonlevel)),
                                new Sylphid(new Random().Next(5,dungeonlevel + 5)),
                            };
                        for (int i = 0; i < enemieNum; i++)
                        {
                            int check;
                            if (bossCheck)
                            {
                                check = new Random().Next(0, Spirit.Count - 1);
                            }
                            else
                            {
                                check = new Random().Next(0, Spirit.Count);
                                if (check == 1)
                                {
                                    bossCheck = true;
                                }
                            }
                            Monster monster = Spirit[check];
                            Enemies.Add((Monster)monster.ShallowCopy());
                        }
                    }
                }
                else if (dungeontype == 3)
                {
                    if (dunlev < 8)
                    {
                        List<Monster> Spirit = new List<Monster>()
                            {
                                new Gnome(new Random().Next(1, dungeonlevel))
                            };
                        for (int i = 0; i < enemieNum; i++)
                        {
                            Monster monster = Spirit[new Random().Next(0, Spirit.Count)];
                            Enemies.Add((Monster)monster.ShallowCopy());
                        }
                    }
                    else
                    {
                        List<Monster> Spirit = new List<Monster>()
                            {
                                new Gnome(new Random().Next(1, dungeonlevel)),
                                new Gnoass(new Random().Next(5, dungeonlevel + 5)),
                            };
                        for (int i = 0; i < enemieNum; i++)
                        {
                            int check;
                            if (bossCheck)
                            {
                                check = new Random().Next(0, Spirit.Count - 1);
                            }
                            else
                            {
                                check = new Random().Next(0, Spirit.Count);
                                if (check == 1)
                                {
                                    bossCheck = true;
                                }
                            }
                            Monster monster = Spirit[check];
                            Enemies.Add((Monster)monster.ShallowCopy());
                        }
                    }
                }
                else if (dungeontype == 4)
                {
                    if (dunlev < 8)
                    {
                        List<Monster> Spirit = new List<Monster>()
                            {
                                new Salamandra(new Random().Next(1, dungeonlevel)),
                            };
                        for (int i = 0; i < enemieNum; i++)
                        {
                            Monster monster = Spirit[new Random().Next(0, Spirit.Count)];
                            Enemies.Add((Monster)monster.ShallowCopy());
                        }
                    }
                    else
                    {
                        List<Monster> Spirit = new List<Monster>()
                            {
                                new Salamandra(new Random().Next(1, dungeonlevel)),
                                new Ifrit(new Random().Next(5,dungeonlevel + 5)),
                            };
                        for (int i = 0; i < enemieNum; i++)
                        {
                            int check;
                            if (bossCheck)
                            {
                                check = new Random().Next(0, Spirit.Count - 1);
                            }
                            else
                            {
                                check = new Random().Next(0, Spirit.Count);
                                if (check == 1)
                                {
                                    bossCheck = true;
                                }
                            }
                            Monster monster = Spirit[check];
                            Enemies.Add((Monster)monster.ShallowCopy());
                        }
                    }
                }
            }
            else if (dungeonnum == 4)
            {
                if (dunlev < 4)
                {
                    List<Monster> Orcs = new List<Monster>()
                        {
                            new Orc(new Random().Next(1,dungeonlevel)),
                            new Ogre(new Random().Next(1,dungeonlevel)),
                        };
                    for (int i = 0; i < enemieNum; i++)
                    {
                        Monster monster = Orcs[new Random().Next(0, Orcs.Count)];
                        Enemies.Add((Monster)monster.ShallowCopy());
                    }
                }
                else if (dunlev >= 4 && dunlev < 8)
                {
                    List<Monster> Orcs = new List<Monster>()
                        {
                            new Troll(new Random().Next(1, dungeonlevel)),
                            new Orc(new Random().Next(1, dungeonlevel)),
                            new Ogre(new Random().Next(1, dungeonlevel)),
                        };
                    for (int i = 0; i < enemieNum; i++)
                    {
                        Monster monster = Orcs[new Random().Next(0, Orcs.Count)];
                        Enemies.Add((Monster)monster.ShallowCopy());
                    }
                }
                else
                {
                    List<Monster> Orcs = new List<Monster>()
                        {
                            new Troll(new Random().Next(1, dungeonlevel)),
                            new Orc(new Random().Next(1, dungeonlevel)),
                            new Ogre(new Random().Next(1, dungeonlevel)),
                            new OgreMage(new Random().Next(5, dungeonlevel + 5))
                        };
                    for (int i = 0; i < enemieNum; i++)
                    {
                        int check;
                        if (bossCheck)
                        {
                            check = new Random().Next(0, Orcs.Count - 1);
                        }
                        else
                        {
                            check = new Random().Next(0, Orcs.Count);
                            if (check == 3)
                            {
                                bossCheck = true;
                            }
                        }
                        Monster monster = Orcs[check];
                        Enemies.Add((Monster)monster.ShallowCopy());
                    }
                }
            }
            else if (dungeonnum == 5)
            {
                List<Monster> Unicon = new List<Monster>()
                    {
                        new Unicon(new Random().Next(1, dungeonlevel))
                    };
                Monster monster = Unicon[new Random().Next(0, Unicon.Count)];
                Enemies.Add((Monster)monster.ShallowCopy());
            }
            else if (dungeonnum == 6)
            {
                List<Monster> Titan = new List<Monster>()
                    {
                        new Titan(new Random().Next(1, dungeonlevel))
                    };
                Monster monster = Titan[new Random().Next(0, Titan.Count)];
                Enemies.Add((Monster)monster.ShallowCopy());
            }
            else if (dungeonnum == 7)
            {
                List<Monster> Dragon = new List<Monster>()
                    {
                        new Dragon(new Random().Next(1, dungeonlevel))
                    };
                Monster monster = Dragon[new Random().Next(0, Dragon.Count)];
                Enemies.Add((Monster)monster.ShallowCopy());
            }
        }

        public void GetBattleReward(Player player)
        {
            var playerGiveExp = 0;
            var playerGiveGold = 0;
            int left = Console.GetCursorPosition().Left;
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
            Console.SetCursorPosition(left + 15, Console.GetCursorPosition().Top);
            Console.WriteLine($"획득경험치 {playerGiveExp}");
        }

        // 적 목록 출력
        public void PrintEnemies(bool writeNum)
        {
            int left = Console.GetCursorPosition().Left;
            Console.WriteLine("[적정보]\n");
            for (int i = 0; i < Enemies.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(left - 6, Console.GetCursorPosition().Top);
                Console.Write(writeNum ? $"[{i + 1}] " : " ");
                Console.ResetColor();
                if (Enemies[i].IsDead)
                {
                    Printing.HighlightText(Enemies[i].ToStringEnemie, ConsoleColor.DarkGray);
                }
                else
                {
                    Console.Write(Enemies[i].ToStringEnemie);
                }
                Console.WriteLine();
            }
        }

        public void PrintPlayer(Player player)
        {
            int left = Console.GetCursorPosition().Left;
            Console.WriteLine("[내정보]\n");
            Console.SetCursorPosition(left - 3, Console.GetCursorPosition().Top);
            Console.WriteLine($"Lv.{player.Level} {player.Name} ({EnumHandler.GetjobKr(player.Job)})");
            Console.SetCursorPosition(left - 2, Console.GetCursorPosition().Top);
            Console.Write("HP : ");
            Printing.HighlightText($"{player.Health,3}/{player.MaxHealth}\n", ConsoleColor.Red);
            Console.SetCursorPosition(left - 2, Console.GetCursorPosition().Top);
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
                msg += $"{monster.ToStringName} 을(를) 맞췄습니다. [데미지 : {finalDmg}]{(IsCritical ? " - 치명타 공격!!" : "")}\n";
                msg += $"{monster.ToStringName}\n";
                msg += $"HP {hp} -> {(monster.IsDead ? "Dead" : $"HP {monster.Health}")}\n";

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
            if (player.Health <= 0) return GameState.BattlePlayerDead;
            int len = BattleEnamiesAttackList.Count;
            if (len == 0) return GameState.BattleGround;

            int uniqueIndex = BattleEnamiesAttackList[len - 1];
            BattleEnamiesAttackList.RemoveAt(len - 1);

            Monster monster = Enemies[uniqueIndex];
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

            return GameState.BattleEnemiesAttack;
        }

        public void DisplayBattle(bool writeNum, GameState gameState, Player player, int skillNo = 0)
        {
            Console.Clear();
            Printing.DrawFrame();
            Console.SetCursorPosition(56, 3);
            Printing.HighlightText("Battle!!", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine();
            switch (gameState)
            {
                case GameState.BattleGround:
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    PrintEnemies(writeNum);
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top + 3);
                    PrintPlayer(player);
                    Console.WriteLine();
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.SelectWriteLine(1, "공격");
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.SelectWriteLine(2, "스킬");
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.SelectWriteLine(0, "도망");
                    Console.WriteLine();
                    Console.SetCursorPosition(54, Console.GetCursorPosition().Top);
                    Printing.HighlightText("플레이어 턴\n", ConsoleColor.Green);
                    break;
                case GameState.BattleAttack:
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    PrintEnemies(writeNum);
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top + 3);
                    PrintPlayer(player);
                    Console.WriteLine();
                    Console.SetCursorPosition(54, Console.GetCursorPosition().Top);
                    Printing.SelectWriteLine(0, "공격취소");
                    Console.WriteLine();
                    Console.SetCursorPosition(54, Console.GetCursorPosition().Top);
                    Printing.HighlightText("플레이어 턴\n", ConsoleColor.Green);
                    break;
                case GameState.BattleAttackEnd:
                    Console.SetCursorPosition(53, Console.GetCursorPosition().Top);
                    foreach (string s in BattleAttackEndMessage.Split("\n"))
                    {
                        Console.WriteLine();
                        Console.SetCursorPosition(40, Console.GetCursorPosition().Top);
                        Console.WriteLine(s);
                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.SelectWriteLine(0, "다음");
                    Console.WriteLine();
                    Console.SetCursorPosition(54, Console.GetCursorPosition().Top);
                    Printing.HighlightText("플레이어 턴\n", ConsoleColor.Green);
                    break;
                case GameState.BattleEnemiesAttack:
                    foreach (string s in BattleEnemiesAttackMessage.Split("\n"))
                    {
                        Console.WriteLine();
                        Console.SetCursorPosition(40, Console.GetCursorPosition().Top);
                        Console.WriteLine(s);
                    }
                    Console.WriteLine();
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.SelectWriteLine(0, "다음");
                    Console.WriteLine();
                    Console.SetCursorPosition(57, Console.GetCursorPosition().Top);
                    Printing.HighlightText("적 턴\n", ConsoleColor.Green);
                    break;
                case GameState.BattlePlayerWin:
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.HighlightText("Victory\n", ConsoleColor.DarkGreen);
                    Console.WriteLine();
                    Console.SetCursorPosition(44, Console.GetCursorPosition().Top);
                    Console.WriteLine($"던전에서 몬스터 {Enemies.Count}마리를 잡았습니다.");
                    Console.WriteLine();
                    Console.SetCursorPosition(39, Console.GetCursorPosition().Top);
                    GetBattleReward(player);
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.SetCursorPosition(54, Console.GetCursorPosition().Top);
                    Console.WriteLine($"HP {PlayerPastHealth} -> {player.Health}");
                    Console.WriteLine();
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Console.WriteLine("0. 다음");
                    break;
                case GameState.BattlePlayerDead:
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.HighlightText("You Lose\n", ConsoleColor.DarkRed);
                    Console.WriteLine();
                    Console.SetCursorPosition(55, Console.GetCursorPosition().Top);
                    Console.WriteLine($"Lv.{player.Level} {player.Name}");
                    Console.SetCursorPosition(54, Console.GetCursorPosition().Top);
                    Console.WriteLine($"HP {PlayerPastHealth} -> {player.Health}");
                    Console.WriteLine();
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.SelectWriteLine(0, "다음");
                    break;
                case GameState.BattleSkillList:
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Console.WriteLine();
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top + 3);
                    PrintPlayer(player);
                    Console.WriteLine();
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top + 3);
                    player.ShowSkillList();
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.SelectWriteLine(0, "취소");
                    Console.WriteLine();
                    Console.SetCursorPosition(54, Console.GetCursorPosition().Top);
                    Printing.HighlightText("플레이어 턴\n", ConsoleColor.Green);
                    break;

                case GameState.BattleSkillAttack:
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    PrintEnemies(writeNum);
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top + 3);
                    PrintPlayer(player);
                    Console.WriteLine();
                    player.ShowSkillList(skillNo);
                    Console.WriteLine();
                    Console.SetCursorPosition(56, Console.GetCursorPosition().Top);
                    Printing.SelectWriteLine(0, "취소");
                    Console.WriteLine();
                    Console.SetCursorPosition(54, Console.GetCursorPosition().Top);
                    Printing.HighlightText("플레이어 턴\n", ConsoleColor.Green);
                    break;
            }
        }
    }
}
