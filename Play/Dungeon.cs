using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Dungeon
    {
        public string Name { get; set; }
        public int FailPer { get; set; }  //실패 확률
        public int RewardGold { get; set; } // 보상 골드
        public int RecomDef { get; set; } // 권장 방어력
        public int RewardExp { get; set; } // 보상 경험치

        public Dungeon(string name, int failPer, int rewardGold, int recomDef, int rewardExp)
        {
            Name = name;
            FailPer = failPer;
            RewardGold = rewardGold;
            RecomDef = recomDef;
            RewardExp = rewardExp;
        }
    }

    public class DungeonGate
    {
        public List<Dungeon> DungeonList;
        public int ReservedDungeon;
        public DungeonGate()
        {
            ReservedDungeon = 0;
            DungeonList = new List<Dungeon> {
                new Dungeon("", 0, 0, 0, 0),
                new Dungeon("고블린 소굴", 40, 1000, 5 , 1),
                new Dungeon("저주받은 지하묘지", 40, 1700, 11, 3),
                new Dungeon("분노한 정령의숲", 40, 2500, 20, 5),
                new Dungeon("더러운 오크동굴", 40, 2500, 25, 5),
                new Dungeon("유니콘 둥지",40, 2500, 35, 5),
                new Dungeon("타이탄의 연무장", 40, 2500, 38, 5),
                new Dungeon("드래곤 레어",40, 2500, 40, 5)
            };
        }

        public int DunCount()
        {
            return DungeonList.Count;
        }

        public void SelectDungeonLevelList()
        {
            Console.Clear();
            Printing.HighlightText("입장하실 던전난이도를 정해주세요\n\n", ConsoleColor.DarkYellow);
            Printing.HighlightText("주의! 낮은확률로 보스몬스터가 출현합니다!\n", ConsoleColor.Red);
            for (int i = 1; i <= 3; i++)
            {
                Printing.SelectWrite(i, $"레벨 {i}까지의 몬스터가 출현합니다\n");
            }
            Printing.SelectWrite(0, "마을로 돌아가기\n");
        }

        public void SelectSpiritTypeList()
        {
            Console.Clear();
            Console.WriteLine("입장하실던전의 타입을 선택해주세요");
            Printing.SelectWrite(1, "맑은물이 흐르는 호수\n");
            Printing.SelectWrite(2, "칼날바람의 숲\n");
            Printing.SelectWrite(3, "영원히타오르는 불의숲\n");
            Printing.SelectWrite(4, "단단한 대지\n");
            Printing.SelectWrite(0, "던전메뉴로 돌아가기\n");
        }

        public void DisplayDungeonList()
        {
            Console.Clear();
            Printing.HighlightText("던전입장", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();

            for (int i = 1; i < DungeonList.Count; i++)
            {
                Printing.SelectWrite(i, DungeonList[i].Name);
                Console.SetCursorPosition(20, 2 + i);
                Console.WriteLine($"| 방어력 {DungeonList[i].RecomDef} 이상 권장");
            }
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }
        
        public void DisplayHealthWarning()
        {
            Console.Clear();
            Printing.HighlightText("던전입장 불가", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("체력이 부족하여 던전에 입장할 수 없습니다.");
            Console.WriteLine("휴식을 취하여 체력을 회복해 주세요.");
            Console.WriteLine();
            Printing.SelectWriteLine(0, "뒤로가기");
            Console.WriteLine();
        }

        public void SetExploreDungeon(int dunNum)
        {
            ReservedDungeon = dunNum;
        }
        public void ExploreDungeonResult(Player player)
        {
            // FIXME : 체력이 0 밑으로 내려가는 경우 처리
            if (ReservedDungeon <= 0 || ReservedDungeon > DungeonList.Count)
            {
                //err
                Console.Clear();
                Printing.HighlightText("던전 클리어 실패", ConsoleColor.DarkYellow);
                Console.WriteLine();
                Printing.HighlightText($"알 수 없는 던전을 클리어 실패 하였습니다.", ConsoleColor.Red);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("[탐험 결과]");
                Console.WriteLine($"체력 {player.Health} -> {player.Health / 2}");

                player.Health -= player.Health / 2;

                Console.WriteLine();
                Printing.SelectWriteLine(0, "나가기");
                Console.WriteLine();
                return;
            }

            // 탐험 결과 계산
            int playerDefSum = player.DefPow + player.ItemDefPow;
            int playerAttSum = player.AttPow + player.ItemAttPow;

            // 방어력으로 실패 계산, 실패시 보상x 체력50%
            if (playerDefSum < DungeonList[ReservedDungeon].RecomDef)
            {
                int ranNum = Util.GenRandomNumber(0, 10);
                if (ranNum < 4)
                {
                    Console.Clear();
                    Printing.HighlightText("던전 클리어 실패", ConsoleColor.DarkYellow);
                    Console.WriteLine();
                    Printing.HighlightText($"{DungeonList[ReservedDungeon].Name}을 클리어 실패 하였습니다.", ConsoleColor.Red);
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("[탐험 결과]");
                    Console.WriteLine($"체력 {player.Health} -> {player.Health / 2}");

                    player.Health -= player.Health / 2;

                    Console.WriteLine();
                    Printing.SelectWriteLine(0, "나가기");
                    Console.WriteLine();
                    return;
                }

            }

            Console.Clear();
            Printing.HighlightText("던전 클리어", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("축하합니다!!");
            Console.WriteLine($"{DungeonList[ReservedDungeon].Name}을 클리어 하였습니다.");
            Console.WriteLine();
            Console.WriteLine("[탐험 결과]");

            // 방어력에 따른 체력 손실 계산
            // FIXME : 방어력 오버로 최소값이 -인 경우 발생 가능
            int minusHP = Util.GenRandomNumber(20 - (playerDefSum - DungeonList[ReservedDungeon].RecomDef)
                , 35 - (playerDefSum - DungeonList[ReservedDungeon].RecomDef));
            Console.Write("체 력 : ");
            Printing.HighlightText($"{player.Health} -> {player.Health - minusHP}\n", ConsoleColor.Red);
            player.Health -= minusHP;

            // 공격력에 따른 보상 계산. 보상의 1.n배
            int plusGold = DungeonList[ReservedDungeon].RewardGold * (Util.GenRandomNumber(playerAttSum, playerAttSum * 2) + 100) / 100;
            Console.Write("Gold : ");
            Printing.HighlightText($"{player.Gold} G -> {player.Gold + plusGold} G\n", ConsoleColor.Yellow);
            player.Gold += plusGold;

            // 경험치
            player.AddExp(DungeonList[ReservedDungeon].RewardExp);

            Console.WriteLine();
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
            ReservedDungeon = 0;
        }
    }
}