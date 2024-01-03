using System;
using System.Collections.Generic;

using System.Text.RegularExpressions;
using textdungeon.Screen;
using static System.Formats.Asn1.AsnWriter;

namespace textdungeon
{
    class Game
    {
        public enum GameState
        {
            Intro,
            Quit,
            Village,
            Status,
            Inventory,
            Equipment,
            Store,
            StoreSale,
            Dungeon,
            Inn,
        }
        public GameState CurrentState { get; set; }


        private Player player;
        private Store store;


        public bool menuActive = true;
        public bool warning = false;

        public Game()
        {
            CurrentState = GameState.Intro;
            store = new Store();
            StartMenu();
        }

        static Player MakeCharacter()
        {
            Console.Clear();
            Console.WriteLine("\n=== 신규 케릭터 생성");
            if (File.Exists("save/save.json"))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("새로운 게임이 시작되면 기존에 저장된 케릭터는 삭제 됩니다.");
                Console.ResetColor();
            }

            string name = GetInputName("케릭터 이름을 입력하세요 (한글,영어,숫자 2~8자):");
            return new Player(name);
        }

        private void SaveGame()
        {
            string jsonData = player.Serialize();
            File.WriteAllText("save/save.json", jsonData);
        }

        private static Player LoadGame()
        {
            string jsonData = File.ReadAllText("save/save.json");
            return Player.Deserialize(jsonData);
        }


        private void StartMenu()
        {
            while (CurrentState == GameState.Intro)
            {
                //int select = Screen.Menu.StartMenu(3);
                int select = UserChoice(GameState.Intro);
                switch (select)
                {
                    case 1:
                        player = MakeCharacter();
                        SaveGame();
                        VillageMenu();
                        break;

                    case 2:
                        player = LoadGame();
                        VillageMenu();
                        break;

                    default:
                        Console.Write("\n아무키나 누르면 프로그램이 종료됩니다(취소: C)...");
                        string input = Console.ReadLine() ?? "";
                        if (input.ToLower() != "c")
                        {
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }


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

                    case 4: // 던전입장
                    case 5: // 휴식하기
                    default: // 저장 후 게임 종료
                        Console.Write("\n아무키나 누르면 프로그램이 종료됩니다(취소: C)...");
                        string input = Console.ReadLine() ?? "";
                        if (input.ToLower() != "c")
                        {
                            SaveGame();
                            Environment.Exit(0);
                        }
                        break;
                }
            }
        }



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
        private void StoreSellMenu()
        {
            //CurrentState = GameState.StoreSale;
            //while (CurrentState == GameState.StoreSale)
            //{
            //    int select = UserChoice(CurrentState);
            //    switch (select)
            //    {
            //        case 0:
            //            CurrentState = GameState.Store;
            //            break;
            //        default:
            //            // 해당 아이템 구매

            //            break;
            //    }
            //}
        }
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
                        // 해당 아이템 구매

                        break;
                }
            }
        }

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
                        int equipType = player.Equipment(select);
                        if (equipType == 0)
                        {
                            warning = true;
                        }
                        else
                        {
                            warning = false;
                        }
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
                    default:
                        CurrentState = GameState.Village;
                        break;
                }
            }
        }

        private int UserChoice(GameState gameState)
        {
            menuActive = true;
            warning = false;
            int inputCount = 0;
            while (menuActive)
            {
                switch (gameState)
                {
                    case GameState.Intro:
                        Printing.StartScreen();
                        inputCount = 3;
                        break;
                    case GameState.Village:
                        Printing.VillageScreen();
                        inputCount = 6;
                        break;
                    case GameState.Status:
                        player.DisplayCharacterStatus();
                        inputCount = 1;
                        break;
                    case GameState.Inventory:
                        player.DisplayInventory();
                        inputCount = 2;
                        break;
                    case GameState.Store:
                        store.DisplayItems(player.Gold);
                        inputCount = 2;
                        break;
                    case GameState.StoreSale:
                        store.ItemSaleList(player.Gold);
                        inputCount = store.ItemCount();
                        break;
                }

                if (warning)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("잘못된 입력입니다.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine();
                }

                Console.WriteLine("원하시는 행동을 입력해주세요.");
                if (inputCount > 1)
                {
                    Console.Write($"[0 - {inputCount - 1}]>> ");
                }
                else
                {
                    Console.Write($"[0]>> ");
                }

                string input = Console.ReadLine() ?? "";
                if (int.TryParse(input, out int number))
                {
                    if (number >= 0 && number < inputCount)
                    {
                        menuActive = false;
                        return number;
                    }
                }

                warning = true;
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("잘못된 입력입니다. 한글,영어,숫자만 2~8자 가능합니다.");
                Console.ResetColor();
            }
        }
    }
}
