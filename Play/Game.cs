using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using textdungeon.Screen;

namespace textdungeon.Play
{
    class Game
    {
        public GameState CurrentState { get; set; }


        private Player player;
        private Store store;
        private Inn inn;
        private DungeonGate dungeonGate;
        private Battle battle;


        public bool menuActive = true;
        ResponseCode response;

        public Game()
        {
            CurrentState = GameState.Intro;
            store = new Store();
            inn = new Inn();
            dungeonGate = new DungeonGate();
            battle = new Battle();
            StartMenu();
        }

        #region Start
        private Player MakeCharacter()
        {
            Console.Clear();
            Console.WriteLine("\n=== 신규 케릭터 생성");
            if (File.Exists("save.json"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("새로운 게임이 시작되면 기존에 저장된 케릭터는 삭제 됩니다.");
                Console.ResetColor();
            }

            string name = GetInputName("케릭터 이름을 입력하세요 (한글,영어,숫자 2~8자):");

            // 직업 선택. 직업별 기본 스탯과 스킬은 다를 수 있다.
            CurrentState = GameState.ClassSelect;
            while (CurrentState == GameState.ClassSelect)
            {
                Console.Clear();
                Console.WriteLine($"케릭터명 : {name}");
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 0:
                        CurrentState = GameState.Village;
                        return null;
                    default:
                        return new Player(name, (CharacterClass)select);
                }
            }

            return null;
        }

        private void SaveGame()
        {
            string jsonData = player.Serialize();
            //Console.WriteLine(jsonData);
            File.WriteAllText("save.json", jsonData);
        }

        private static Player LoadGame()
        {
            string jsonData = File.ReadAllText("save.json");
            return Player.Deserialize(jsonData);
        }


        public void StartMenu()
        {
            CurrentState = GameState.Intro;
            while (CurrentState == GameState.Intro)
            {
                //int select = Screen.Menu.StartMenu(3);
                int select = UserChoice(GameState.Intro);
                switch (select)
                {
                    case 1:
                        player = MakeCharacter();
                        if (player == null)
                        {
                            CurrentState = GameState.Intro;
                            break;
                        }
                        // 직업에 맞춰 아이템 생성을 위한 ItemInit
                        store.ItemInit(player.Job);
                        SaveGame();
                        VillageMenu();
                        break;

                    case 2:
                        player = LoadGame();
                        player.EquipItemAll();
                        // 직업에 맞춰 아이템 생성을 위한 ItemInit
                        store.ItemInit(player.Job);
                        // 스토어랑 템 싱크
                        store.ItemBoughtSync(player.Items);
                        VillageMenu();
                        break;

                    default:
                        Console.Write("\n아무키나 누르면 프로그램이 종료됩니다(취소: C)...");
                        while (Console.ReadKey().Key != ConsoleKey.C)
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }
        #endregion

        // 메인 게임 루프
        private void VillageMenu()
        {
            CurrentState = GameState.Village;
            while (true)
            {
                int select = UserChoice(GameState.Village);
                switch (select)
                {
                    case 1: // 상태보기
                        PlayerStateMenu();
                        break;
                    case 2: // 인벤토리
                        PlayerInventoryMenu();
                        break;
                    case 3: // 상점
                        StoreMenu();
                        break;
                    case 4: // 던전
                        DungeonMenu();
                        break;
                    case 5: // 휴식하기
                        InnMenu();
                        break;
                    case 6: // 퀘스트
                        QuestMenu();
                        break;
                    default: // 저장 후 게임 종료
                        Console.Write("\n아무키나 누르면 프로그램이 종료됩니다(취소: C)...");
                        while (Console.ReadKey().Key != ConsoleKey.C)
                        {
                            SaveGame();
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }

        private void QuestMenu()
        {
            // 길드. 퀘스트 받는곳
            CurrentState = GameState.Quest;
            while (CurrentState == GameState.Quest)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 0:
                        CurrentState = GameState.Village;
                        break;
                    default:
                        QuestDetail(select);
                        break;

                }
            }

        }

        private void QuestDetail(int questId)
        {
            // 길드. 퀘스트 받는곳
            CurrentState = GameState.QuestDetail;
            while (CurrentState == GameState.QuestDetail)
            {
                int select = UserChoice(CurrentState, new int[] { questId });
                switch (select)
                {
                    case 1:
                        // 수락 or 보상 수령
                        response = player.UpdateQuest(questId);
                        CurrentState = GameState.Quest;
                        break;
                    case 0:
                    case 2:
                    default:
                        CurrentState = GameState.Quest;
                        break;
                }
            }
        }

        #region Inn
        private void InnMenu()
        {
            CurrentState = GameState.Inn;
            while (CurrentState == GameState.Inn)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 1:
                        response = inn.Rest(player);
                        break;
                    default:
                        CurrentState = GameState.Village;
                        break;

                }
            }
        }
        #endregion

        #region Dungeon
        private void DungeonMenu()
        {
            Random rand = new Random();
            int monsternum = rand.Next(1, 4);
            CurrentState = GameState.DungeonGate;
            while (CurrentState == GameState.DungeonGate)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 1:
                        battle.PlayerPastHealth = player.Health;
                        //유저가 선택한 던전의 번호를 입력받음
                        battle.SelectDungeon(1);
                        battle.NewBattle(monsternum);
                        ExploreBattle();
                        break;
                    case 2:
                        battle.PlayerPastHealth = player.Health;
                        //유저가 선택한 던전의 번호를 입력받음
                        battle.SelectDungeon(2);
                        battle.NewBattle(monsternum);
                        ExploreBattle();
                        break;
                    case 3:
                        battle.PlayerPastHealth = player.Health;
                        //유저가 선택한 던전의 번호를 입력받음
                        battle.SelectDungeon(3);
                        battle.NewBattle(monsternum);
                        ExploreBattle();
                        break;
                    case 4:
                        battle.PlayerPastHealth = player.Health;
                        //유저가 선택한 던전의 번호를 입력받음
                        battle.SelectDungeon(4);
                        battle.NewBattle(monsternum);
                        ExploreBattle();
                        break;
                    case 5:
                        battle.PlayerPastHealth = player.Health;
                        //유저가 선택한 던전의 번호를 입력받음
                        battle.SelectDungeon(5);
                        battle.NewBattle(monsternum);
                        ExploreBattle();
                        break;
                    case 6:
                        battle.PlayerPastHealth = player.Health;
                        //유저가 선택한 던전의 번호를 입력받음
                        battle.SelectDungeon(6);
                        battle.NewBattle(monsternum);
                        //battle.NewBattle(1, 0, 1, 3);
                        ExploreBattle();
                        break;
                    default:
                        CurrentState = GameState.Village;
                        break;
                }
            }
        }
        
        private void ExploreDungeon()
        {
            CurrentState = GameState.DungeonResult;
            while (CurrentState == GameState.DungeonResult)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 0:
                        CurrentState = GameState.DungeonGate;
                        break;
                }
            }
        }

        // 전투화면(공격, 스킬, 아이템 선택화면)
        private void ExploreBattle()
        {
            CurrentState = GameState.BattleGround;
            while (CurrentState == GameState.BattleGround)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 0:
                        CurrentState = GameState.BattleAttack;
                        AtteckBattle();
                        break;
                        //case 1: // 스킬?
                        //    break;
                }
            }
        }

        // 전투공격화면(작 몬스터를 선택해서 공격)
        private void AtteckBattle()
        {
            CurrentState = GameState.BattleAttack;
            while (CurrentState == GameState.BattleAttack)
            {
                int select = UserChoice(CurrentState);
                if (select == 0) // 공격취소
                {
                    CurrentState = GameState.BattleGround;
                }
                else if (battle.PlayerAttackSelect(player, select, player.NormalDamage)) // 공격대상 선택(기본공격)
                {
                    AttackBattleEnd();
                }
            }
        }

        // 전투 공격결과 화면
        private void AttackBattleEnd()
        {
            CurrentState = GameState.BattleAttackEnd;
            while (CurrentState == GameState.BattleAttackEnd)
            {
                int select = UserChoice(CurrentState);
                if (select == 0) // 다음
                {
                    battle.BattleEnamiesAttackList.Clear();
                    for (int i = 0; i < battle.Enemies.Count; i++)
                    {
                        if (!battle.Enemies[i].IsDead)
                        {
                            battle.BattleEnamiesAttackList.Add(battle.Enemies[i].UniqueID);
                        }
                    }

                    if (battle.BattleEnamiesAttackList.Count != 0)
                    {
                        battle.EnemiesAttack(player);
                        AttackEnemiesBattle();
                    }
                    else
                    {
                        player.UpdateQuestProgress(QuestType.MonsterHunt, 0, 3);
                        PlayerWinBattle();
                    }
                }
            }
        }

        // 전투에서 플레이어 승리
        private void PlayerWinBattle()
        {
            CurrentState = GameState.BattlePlayerWin;
            while (CurrentState == GameState.BattlePlayerWin)
            {
                int select = UserChoice(CurrentState);
                if (select == 0) // 다음
                {
                    CurrentState = GameState.Village;
                }
            }
        }

        // 전투중 적의 공격
        private void AttackEnemiesBattle()
        {
            CurrentState = GameState.BattleEnemiesAttack;
            while (CurrentState == GameState.BattleEnemiesAttack)
            {
                int select = UserChoice(CurrentState);
                if (select == 0) // 다음
                {
                    CurrentState = battle.EnemiesAttack(player);
                    switch (CurrentState)
                    {
                        case GameState.BattleGround:
                        case GameState.BattleEnemiesAttack:
                            break;
                        case GameState.BattlePlayerDead:
                            PlayerDeadBattle();
                            break;
                    } 
                }
            }
        }
        // 전투에서 플레이어 패배
        private void PlayerDeadBattle()
        {
            CurrentState = GameState.BattlePlayerDead;
            while (CurrentState == GameState.BattlePlayerDead)
            {
                int select = UserChoice(CurrentState);
                if (select == 0) // 다음
                {
                    CurrentState = GameState.Village;
                }
            }
        }
        #endregion

        #region Store
        // 상점
        private void StoreMenu()
        {
            CurrentState = GameState.Store;
            while (CurrentState == GameState.Store)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 1:
                        StoreSaleMenu();
                        break;
                    case 2:
                        StoreSellMenu();
                        break;
                    default:
                        CurrentState = GameState.Village;
                        break;
                }
            }
        }

        // 상점 - 2. 아이템 판매
        private void StoreSellMenu()
        {
            CurrentState = GameState.StoreSell;
            while (CurrentState == GameState.StoreSell)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 0:
                        CurrentState = GameState.Store;
                        break;
                    default:
                        // 해당 아이템 판매
                        response = store.SellItems(player, select);
                        break;
                }
            }
        }

        // 상점 - 1. 아이템 구매
        private void StoreSaleMenu()
        {
            CurrentState = GameState.StoreSale;
            while (CurrentState == GameState.StoreSale)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 0:
                        CurrentState = GameState.Store;
                        break;
                    default:
                        response = store.BuyItems(player, select);
                        break;
                }
            }
        }

        #endregion

        #region Player
        private void PlayerInventoryMenu()
        {
            CurrentState = GameState.Inventory;
            while (CurrentState == GameState.Inventory)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 1: // 장착 관리
                        EquipmentManager();
                        break;
                    default:
                        CurrentState = GameState.Village;
                        break;
                }
            }
        }

        private void EquipmentManager()
        {
            CurrentState = GameState.Equipment;
            while (CurrentState == GameState.Equipment)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 0:
                        CurrentState = GameState.Inventory;
                        break;
                    default:
                        response = player.Equipment(select);
                        break;
                }
            }
        }

        private void PlayerStateMenu()
        {
            CurrentState = GameState.Status;
            while (CurrentState == GameState.Status)
            {
                int select = UserChoice(CurrentState);
                switch (select)
                {
                    case 0:
                        CurrentState = GameState.Village;
                        break;
                }
            }
        }
        #endregion

        private int UserChoice(GameState gameState, int[] args = null)
        {
            menuActive = true;
            int inputCount = 0;
            while (menuActive)
            {
                switch (gameState)
                {
                    case GameState.Intro:
                        Printing.StartScreen();
                        inputCount = 3;
                        break;
                    case GameState.ClassSelect:
                        Printing.SelectClassScene();
                        inputCount = Enum.GetValues(typeof(CharacterClass)).Length;
                        break;
                    case GameState.Village:
                        Printing.VillageScreen();
                        inputCount = 7;
                        break;
                    case GameState.Status:
                        player.DisplayCharacterStatus();
                        inputCount = 1;
                        break;
                    case GameState.Inventory:
                        player.DisplayInventory();
                        inputCount = 2;
                        break;
                    case GameState.Equipment:
                        player.EquipmentManager();
                        inputCount = player.ItemCount();
                        break;
                    case GameState.Store:
                        store.DisplayItems(player.Gold);
                        inputCount = 3;
                        break;
                    case GameState.StoreSale:
                        store.ItemSaleList(player.Gold);
                        inputCount = store.ItemCount();
                        break;
                    case GameState.StoreSell:
                        store.ItemSellList(player);
                        inputCount = player.ItemCount();
                        break;
                    case GameState.DungeonGate:
                        dungeonGate.DisplayDungeonList();
                        inputCount = dungeonGate.DunCount() + 1;
                        break;
                    case GameState.DungeonResult:
                        dungeonGate.ExploreDungeonResult(player);
                        inputCount = 1;
                        break;
                    case GameState.Inn:
                        inn.InnMenu(player);
                        inputCount = 2;
                        break;
                    // 전투 흐름 구현 필요
                    case GameState.BattleGround:
                        battle.DisplayBattle(false, GameState.BattleGround, player);
                        inputCount = 1;
                        break;
                    case GameState.BattleAttack: // 공격 화면
                        battle.DisplayBattle(true, GameState.BattleAttack, player);
                        inputCount = battle.Enemies.Count + 1;
                        break;
                    case GameState.BattleAttackEnd: // 공격후 공격결과화면
                        battle.DisplayBattle(false, GameState.BattleAttackEnd, player);
                        inputCount = 1;
                        break;
                    case GameState.BattleEnemiesAttack: // 적의 턴
                        battle.DisplayBattle(false, GameState.BattleEnemiesAttack, player);
                        inputCount = 1;
                        break;
                    case GameState.BattlePlayerWin: // 플레이어 승리
                        battle.DisplayBattle(false, GameState.BattlePlayerWin, player);
                        inputCount = 1;
                        break;
                    case GameState.BattlePlayerDead: // 플레이어 패배
                        battle.DisplayBattle(false, GameState.BattlePlayerDead, player);
                        inputCount = 1;
                        break;

                    // case GameState.BattleSkill:
                    //     battle.DisplayBattle(false, BattleAttack.BattleSkillList, player);
                    //     // inputCount = // 스킬개수
                    //     break;
                    // case GameState.BattleSkillAttack:
                    //     battle.DisplayBattle(false, BattleAttack.BattleSkillAttack, player);
                    //     // inputCount = // 스킬개수
                    //     break;

                    // case GameState.BattleSkillList: break;
                    // case GameState.BattleSkillAttack: break;
                    case GameState.Quest:
                        player.ShowAllQuestInfo();
                        inputCount = player.GetAllQuestCount();
                        break;
                    case GameState.QuestDetail:
                        player.ShowQuestDetail(args[0]);
                        QuestState state = player.GetQuestState(args[0]);
                        inputCount = (state == QuestState.NotStarted || state == QuestState.ObjectiveCompleted) ? 2 : 1;
                        break;
                }

                if (response != ResponseCode.SUCCESS)
                {
                    if ((int)response < 200)
                    {
                        Printing.HighlightText(EnumHandler.GetMessage(response), ConsoleColor.Blue);
                    }
                    else
                    {
                        Printing.HighlightText(EnumHandler.GetMessage(response), ConsoleColor.Red);
                    }
                }
                else
                {
                    Console.WriteLine();
                }

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                if (inputCount > 1)
                {
                    Printing.HighlightText($"[0 - {inputCount - 1}]", ConsoleColor.Green);
                    Console.Write(" >> ");
                }
                else
                {
                    Printing.HighlightText("[0]", ConsoleColor.Green);
                    Console.Write(" >> ");
                }

                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int number))
                {
                    if (number >= 0 && number < inputCount)
                    {
                        response = ResponseCode.SUCCESS;
                        menuActive = false;
                        return number;
                    }
                    else
                    {
                        response = ResponseCode.BADREQUEST;
                    }
                }
                else
                {
                    // 치트키
                    switch (input)
                    {
                        case "gold":
                            if (player != null)
                            {
                                player.Gold += 5000;
                            }
                            else
                            {
                                response = ResponseCode.BADREQUEST;
                            }
                            break;
                        case "test":
                            break;
                        case "questtest":

                            break;
                        default:
                            response = ResponseCode.BADREQUEST;
                            break;
                    }
                }

            }
            return 0;
        }


        private static string GetInputName(string text)
        {
            string pattern = @"^[a-zA-Z0-9가-힣]{2,8}$";
            while (true)
            {
                Console.Write(text);
                string input = Console.ReadLine() ?? "";

                if (Regex.IsMatch(input, pattern))
                {
                    return input;
                }
                Printing.HighlightText("잘못된 입력입니다. 한글,영어,숫자만 2~8자 가능합니다.\n", ConsoleColor.Red);
            }
        }

    }
}
