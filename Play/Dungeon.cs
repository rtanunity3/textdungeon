using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Dungeon
    {
        public string Name { get; set; }
        public int FailPer { get; set; }  //실패 확률
        public int RewardGold { get; set; } // 보상 골드
        public int RecomDef { get; set; } // 권장 방어력

        public Dungeon(string name, int failPer, int rewardGold, int recomDef)
        {
            Name = name;
            FailPer = failPer;
            RewardGold = rewardGold;
            RecomDef = recomDef;
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
                new Dungeon("", 0, 0, 0),
                new Dungeon("쉬운 던전", 40, 1000, 5),
                new Dungeon("일반 던전", 40, 1700, 11),
                new Dungeon("어려운 던전", 40, 2500, 17)
            };
        }

        public int DunCount()
        {
            return DungeonList.Count;
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
            Console.WriteLine("4. 임시전투 테스트");
            Printing.SelectWriteLine(0, "나가기");
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
            player.AddExp(1);

            Console.WriteLine();
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
            ReservedDungeon = 0;
        }
    }
}