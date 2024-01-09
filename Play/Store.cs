using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Store
    {
        public List<Item> ItemList;

        int[] itemTableColWidth = { 25, 40, 55, 110 };
        int itemInfoTableTop = 7;

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

        public void ItemBoughtSync(List<Item> playerItems)
        {
            foreach (var playerItem in playerItems)
            {
                foreach (var storeItem in ItemList)
                {
                    if (storeItem.ItemId == playerItem.ItemId)
                    {
                        storeItem.IsBought = true;
                    }
                }
            }
        }


        public void DisplayItems(int gold)
        {
            Console.Clear();
            Printing.HighlightText("상점", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Printing.HighlightText($"{gold} G\n", ConsoleColor.Yellow);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Printing.StoreItemInfoTableTitle(itemTableColWidth, itemInfoTableTop);

            for (int i = 1; i < ItemCount(); i++)
            {
                ItemList[i].ItemInfoWrite(itemTableColWidth, itemInfoTableTop, i);
            }

            Console.WriteLine();
            Printing.SelectWriteLine(1, "아이템 구매");
            Printing.SelectWriteLine(2, "아이템 판매");
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public void ItemSaleList(int gold)
        {
            Console.Clear();
            Printing.HighlightText("상점 - 아이템 구매", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Printing.HighlightText($"{gold} G\n", ConsoleColor.Yellow);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Printing.StoreItemInfoTableTitle(itemTableColWidth, itemInfoTableTop);

            for (int i = 1; i < ItemCount(); i++)
            {
                ItemList[i].ItemInfoWrite(itemTableColWidth, itemInfoTableTop, i, true);
            }

            Console.WriteLine();
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public void ItemSellList(Player player)
        {
            Console.Clear();
            Printing.HighlightText("상점 - 아이템 판매", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Printing.HighlightText($"{player.Gold} G\n", ConsoleColor.Yellow);
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Printing.StoreItemInfoTableTitle(itemTableColWidth, itemInfoTableTop);

            for (int i = 1; i < player.ItemCount(); i++)
            {
                player.Items[i].ItemInfoWrite(itemTableColWidth, itemInfoTableTop, i, true, false, true);
            }

            Console.WriteLine();
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public ResponseCode BuyItems(Player player, int select)
        {
            if (ItemList[select].IsBought)
            {
                //이미 구매함
                return ResponseCode.ALREADYBOUGHT;
            }
            else if (player.Gold >= ItemList[select].Cost)
            {
                player.Gold -= ItemList[select].Cost;
                player.AddItem(ItemList[select]);

                ItemList[select].IsBought = true; // 구매 처리
                // 구매 가능
                return ResponseCode.BOUGHTCOMPLETE;
            }
            else
            {
                return ResponseCode.NOTENOUGHGOLD;
            }
        }
        public ResponseCode SellItems(Player player, int select)
        {
            // 상점 데이터 업데이트 : Bought값
            foreach (Item item in ItemList)
            {
                if (item.ItemId == player.Items[select].ItemId)
                {
                    item.IsBought = false;
                }
            }

            // 플레이어 데이터 업데이트 : 장착, 소유아이템, 골드, 아이템 능력치
            player.UnEquipItem(player.Items[select].ItemId);
            player.Gold += (int)(player.Items[select].Cost * 0.85f);
            player.RemoveItem(player.Items[select]);
            player.CalcItemStat();

            return ResponseCode.SELLCOMPLETE;
        }

    }
}
