using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textdungeon.Screen
{
    public static class Printing
    {
        static void HighlightText(string text, ConsoleColor textColor)
        {
            HighlightText(text, textColor, ConsoleColor.Black);
        }

        static void HighlightText(string text, ConsoleColor textColor, ConsoleColor bgColor)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = bgColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void StartScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("   _____________________________________________________");
            Console.WriteLine("  |                                                     |");
            Console.WriteLine("  |                  용   사    마   을                 |");
            Console.WriteLine("  |                                                     |");
            Console.WriteLine("  |-----------------------------------------------------|");
            Console.WriteLine("  |                                                     |");
            Console.WriteLine("  |                                                     |");
            Console.WriteLine("  |                   1. 새로운 시작                    |");
            if (File.Exists("save/save.json"))
            {
                Console.WriteLine("  |                   2. 이어서하기                     |");
            }
            Console.WriteLine("  |                   0. 게임 종료                      |");
            Console.WriteLine("  |                                                     |");
            Console.WriteLine("  |_____________________________________________________|");
            Console.WriteLine();
        }

        public static void VillageScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전입장");
            Console.WriteLine("5. 휴식하기");
            Console.WriteLine("0. 게임 저장 후 종료");
            Console.WriteLine();
        }


    }
}
