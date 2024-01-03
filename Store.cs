using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textdungeon
{
    public class Store
    {
        public List<Item> ItemList;

        public Store()
        {
            // 요구사항에 따라 아이템 항목을 유니크하도록 수정
            ItemList = new List<Item> {
                new Item(false, false, 0, 0, 0, "", "", 0),
                new Item(false, false, 1001, 0, 1, "수련자 투구", "수련에 도움을 주는 갑옷입니다.", 1000),
                new Item(false, false, 1002, 0, 2, "무쇠 투구", "무쇠로 만들어져 튼튼한 투구입니다.", 2000),
                new Item(false, false, 1003, 0, 4, "스파르타의 투구", "스파르타의 전사들이 사용했다는 전설의 투구입니다.", 3500),
                new Item(false, false, 2001, 0, 5, "수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 1000),
                new Item(false, false, 2002, 0, 9, "무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000),
                new Item(false, false, 2003, 0, 15, "스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500),
                new Item(false, false, 3001, 4, 0, "낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 1000),
                new Item(false, false, 3002, 8, 0, "청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 2000),
                new Item(false, false, 3003, 16, 0, "스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3500),
                new Item(false, false, 4001, 1, 2, "낡은 방패", "쉽게 볼 수 있는 낡은 방패 입니다.", 1000),
                new Item(false, false, 4002, 2, 5, "청동 방패", "어디선가 사용됐던거 같은 방패입니다.", 2000),
                new Item(false, false, 4003, 3, 9, "스파르타의 방패", "스파르타의 전사들이 사용했다는 전설의 방패입니다.", 3500)
            };
        }

        public List<Item> GetItems()
        {
            return ItemList;
        }

        public int ItemCount()
        {
            return ItemList.Count;
        }


        public void DisplayItems(int gold)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Console.Write("- 아이템 이름");
            Console.SetCursorPosition(20, 6);
            Console.Write("| 공격력");
            Console.SetCursorPosition(35, 6);
            Console.Write("| 방어력");
            Console.SetCursorPosition(50, 6);
            Console.Write("| 아이템 설명");
            Console.SetCursorPosition(100, 6);
            Console.Write("| 가격");
            Console.WriteLine();

            for (int i = 1; i < ItemCount(); i++)
            {

                Console.Write($"- {ItemList[i].Name}");
                Console.SetCursorPosition(20, 6 + i);
                if (ItemList[i].ItemAttPow != 0)
                {
                    Console.Write($"| 공격력 +{ItemList[i].ItemAttPow}\t");

                }
                Console.SetCursorPosition(35, 6 + i);
                if (ItemList[i].ItemDefPow != 0)
                {
                    Console.Write($"| 방어력 +{ItemList[i].ItemDefPow}\t");

                }
                Console.SetCursorPosition(50, 6 + i);
                Console.Write($"| {ItemList[i].Desc}\t");
                Console.SetCursorPosition(100, 6 + i);
                if (ItemList[i].Bought)
                {
                    Console.Write($"| 구매완료\n");
                }
                else
                {
                    Console.Write($"| {ItemList[i].Cost} G\n");
                }
            }

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        public void ItemSaleList(int gold)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상점 - 아이템 구매");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{gold} G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Console.Write("- 아이템 이름");
            Console.SetCursorPosition(20, 6);
            Console.Write("| 공격력");
            Console.SetCursorPosition(35, 6);
            Console.Write("| 방어력");
            Console.SetCursorPosition(50, 6);
            Console.Write("| 아이템 설명");
            Console.SetCursorPosition(100, 6);
            Console.Write("| 가격");
            Console.WriteLine();

            for (int i = 1; i < ItemCount(); i++)
            {

                Console.Write($"- {i} {ItemList[i].Name}");
                Console.SetCursorPosition(20, 6 + i);
                if (ItemList[i].ItemAttPow != 0)
                {
                    Console.Write($"| 공격력 +{ItemList[i].ItemAttPow}\t");

                }
                Console.SetCursorPosition(35, 6 + i);
                if (ItemList[i].ItemDefPow != 0)
                {
                    Console.Write($"| 방어력 +{ItemList[i].ItemDefPow}\t");

                }
                Console.SetCursorPosition(50, 6 + i);
                Console.Write($"| {ItemList[i].Desc}\t");
                Console.SetCursorPosition(100, 6 + i);
                if (ItemList[i].Bought)
                {
                    Console.Write($"| 구매완료\n");
                }
                else
                {
                    Console.Write($"| {ItemList[i].Cost} G\n");
                }
            }

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        public void BuyItems(int gold)
        {
            return;
        }
    }
}
