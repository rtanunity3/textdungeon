using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Item
    {
        public bool IsEquipped { get; set; }
        public bool IsBought { get; set; }

        /*
        itemId
        1001~2000 : 머리
        2001~3000 : 갑옷
        3001~4000 : 무기
        4001~5000 : 방패
        */
        public int ItemId { get; }
        public int ItemAttPow { get; }
        public int ItemDefPow { get; }

        public string Name { get; }
        public string Desc { get; }

        public int Cost { get; }

        public Item(bool equipped, bool bought, int itemId, int itemAttPow, int itemDefPow, string name, string desc, int cost)
        {
            IsEquipped = equipped;
            IsBought = bought;
            ItemId = itemId;
            ItemAttPow = itemAttPow;
            ItemDefPow = itemDefPow;
            Name = name;
            Desc = desc;
            Cost = cost;
        }

        /// <summary>
        /// 아이템 정보 출력
        /// </summary>
        /// <param name="itemTableColWidth">테이블 컬럼 간격</param>
        /// <param name="defaultHeight">테이블 시작 높이</param>
        /// <param name="i">인덱스</param>
        /// <param name="writeNum">숫자표시 여부</param>
        /// <param name="isSale">상점 여부 false=인벤토리</param>
        /// <param name="isSell">아이템 판매인 경우</param>
        /// <returns>void</returns>
        public void ItemInfoWrite(int[] itemTableColWidth, int defaultHeight, int i
            , bool writeNum = false, bool isSale = true, bool isSell = false)
        {
            ConsoleColor boughtColor = ConsoleColor.DarkGray;
            if (!isSale)
            {
                boughtColor = ConsoleColor.Gray;
            }

            Printing.HighlightText("-", IsBought ? boughtColor : ConsoleColor.Gray);
            if (writeNum)
            {
                Printing.HighlightText($"{i,2} ", ConsoleColor.Green);
            }
            else
            {
                Console.Write($"   ");
            }

            if (!isSale)
            {
                if (IsEquipped)
                {
                    Printing.HighlightText("[E]", ConsoleColor.Cyan);
                }
            }
            if (IsBought)
            {
                Console.ForegroundColor = boughtColor;
            }
            Console.Write($"{Name}");
            Console.SetCursorPosition(itemTableColWidth[0], defaultHeight + i);
            Console.Write($"| ");
            if (ItemAttPow != 0)
            {
                Console.Write($"공격력 +{ItemAttPow}");

            }
            Console.SetCursorPosition(itemTableColWidth[1], defaultHeight + i);
            Console.Write($"| ");
            if (ItemDefPow != 0)
            {
                Console.Write($"방어력 +{ItemDefPow}");

            }
            Console.SetCursorPosition(itemTableColWidth[2], defaultHeight + i);
            Console.Write($"| {Desc}");
            Console.SetCursorPosition(itemTableColWidth[3], defaultHeight + i);
            Console.Write($"| ");

            Console.ResetColor();

            if (isSale)
            {
                if (IsBought)
                {
                    Printing.HighlightText("구매완료\n", boughtColor);
                }
                else
                {
                    Printing.HighlightText($"{Cost} G\n", ConsoleColor.Yellow);
                }
            }
            else if (isSell)
            {
                Printing.HighlightText($"{Cost * 0.85} G\n", ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
