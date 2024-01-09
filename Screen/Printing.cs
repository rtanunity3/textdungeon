using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textdungeon.Screen
{
    public static class Printing
    {
        /*
        location : darkyellow
        tabletitle : darkgray
        gold : yellow
        select : green
        warning: red
        Equip : cyan
        */
        public static void HighlightText(string text, ConsoleColor textColor)
        {
            HighlightText(text, textColor, ConsoleColor.Black);
        }

        public static void HighlightText(string text, ConsoleColor textColor, ConsoleColor bgColor)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = bgColor;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void SelectWriteLine(int num, string content)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{num}. ");
            Console.ResetColor();
            Console.WriteLine(content);
        }
        public static void SelectWrite(int num, string content)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{num}. ");
            Console.ResetColor();
            Console.Write(content);
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
            Console.Write("  |                   ");
            SelectWrite(1, "새로운 시작");
            Console.WriteLine("                    |");
            if (File.Exists("save.json"))
            {
                Console.Write("  |                   ");
                SelectWrite(2, "이어서하기");
                Console.WriteLine("                     |");
            }
            Console.Write("  |                   ");
            SelectWrite(0, "게임 종료");
            Console.WriteLine("                      |");
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
            SelectWriteLine(1, "상태보기");
            SelectWriteLine(2, "인벤토리");
            SelectWriteLine(3, "상점");
            SelectWriteLine(4, "던전입장");
            SelectWriteLine(5, "휴식하기");
            SelectWriteLine(0, "게임 저장 후 종료");
            Console.WriteLine();
        }

        public static void StoreItemInfoTableTitle(int[] itemTableColWidth, int itemInfoTableTop)
        {
            HighlightText("    아이템 이름", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[0], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("공격력", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[1], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("방어력", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[2], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("아이템 설명", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[3], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("가격", ConsoleColor.DarkGray);
            Console.WriteLine();
        }

        public static void ItemInfoTableTitle(int[] itemTableColWidth, int itemInfoTableTop)
        {
            HighlightText("    아이템 이름", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[0], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("공격력", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[1], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("방어력", ConsoleColor.DarkGray);
            Console.SetCursorPosition(itemTableColWidth[2], itemInfoTableTop);
            Console.Write("| ");
            HighlightText("아이템 설명", ConsoleColor.DarkGray);
            Console.WriteLine();
        }
    }
}
