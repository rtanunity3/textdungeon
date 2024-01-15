using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Inn
    {
        public void InnMenu(Player player)
        {
            Console.Clear();
            Printing.HighlightText("휴식하기", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine($"500 G 를 내면 체력과 마나를 회복할 수 있습니다.");

            Console.WriteLine();
            Console.Write("보유 골드 : ");
            Printing.HighlightText($"{player.Gold} G\n", ConsoleColor.Yellow);
            Console.Write("현재 체력 : ");
            Printing.HighlightText($"{player.Health,3}/{player.MaxHealth}\n", ConsoleColor.Red);
            Console.Write("현재 마나 : ");
            Printing.HighlightText($"{player.Mana,3}/{player.MaxMana}\n", ConsoleColor.Blue);

            Console.WriteLine();
            Printing.SelectWriteLine(1, "휴식하기");
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }


        public ResponseCode Rest(Player player)
        {
            if (player.Gold >= 500)
            {
                player.Health = player.MaxHealth;
                player.Mana = player.MaxMana;
                player.Gold -= 500;

                return ResponseCode.REST;
            }
            else
            {
                return ResponseCode.NOTENOUGHGOLD;
            }
        }
    }
}
