using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Inn
    {
        public void InnMenu(int gold)
        {
            Console.Clear();
            Printing.HighlightText("휴식하기", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine($"500 G 를 내면 체력을 회복할 수 있습니다. (보유 골드 : {gold} G)");

            Console.WriteLine();
            Printing.SelectWriteLine(1, "휴식하기");
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }


        public ResponseCode Rest(Player player)
        {
            if (player.Gold >= 500)
            {
                player.Health = 100;
                player.Gold -= 500;

                return ResponseCode.REST;
            }
            else {
                return ResponseCode.NOTENOUGHGOLD;
            }
        }
    }
}
