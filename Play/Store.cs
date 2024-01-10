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
                new NoviceHelmet(),
                new IronHelmet(),
                new SpartanHelmet(),
                new NoviceArmor(),
                new IronArmor(),
                new SpartanArmor(),
                new OldSword(),
                new BronzeAxe(),
                new SpartanSpear(),
                new OldShield(),
                new BronzeShield(),
                new SpartanShield(),
                new HealingPotion()
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
