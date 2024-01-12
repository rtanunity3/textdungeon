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

        // 수량 부분 출력을 위해 추가.
        int[] itemTableColWidth = { 24, 37, 50, 103, 113 };
        int itemInfoTableTop = 7;

        public Store()
        {
            ItemList = new List<Item>();
        }

        // 플레이어 직업이 추가되어 따로 구현한 상인 아이템 초기 생성 코드.
        public void ItemInit(CharacterClass playerClass)
        {
            // 요구사항에 따라 아이템 항목을 유니크하도록 수정
            // ItemCatalog에 있는 아이템들로 생성되게 변경.
            // 플레이어의 직업에 맞춰서 아이템 생성.
            switch (playerClass)
            {
                case CharacterClass.Warrior: ItemList.AddRange(new WarriorItems().List); break;
                case CharacterClass.Mage: ItemList.AddRange(new MageItems().List); break;
                case CharacterClass.Archer: ItemList.AddRange(new ArcherItems().List); break;
                case CharacterClass.Thief: ItemList.AddRange(new ThiefItems().List); break;
                case CharacterClass.Cleric: ItemList.AddRange(new ClericItems().List); break;
            }
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
                // 소모품이 아닌 경우만
                //NOTE 현재 소모품 판매는 무한대로 하고 있음.
                EquipmentType type = EnumHandler.GetEquipmentType(playerItem.ItemId);
                if (type != EquipmentType.Consumable)
                {
                    foreach (var storeItem in ItemList)
                    {
                        if (storeItem.ItemId == playerItem.ItemId)
                        {
                            storeItem.IsBought = true;
                            storeItem.Quantity = 0;
                        }
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

                // 소모품이 아닐 경우 구매 처리
                EquipmentType type = EnumHandler.GetEquipmentType(ItemList[select].ItemId);
                if (type != EquipmentType.Consumable)
                {
                    ItemList[select].Quantity = 0;
                    ItemList[select].IsBought = true;
                }
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
                // 수량이 1개일 경우에만 처리.
                //NOTE 아이템A의 수량이 여러 개일 때, 판매시의 처리를 생각해봐야함.
                //NOTE 현재는 모두 판매해야지만 상점에서 구매 가능.
                if (item.ItemId == player.Items[select].ItemId && player.Items[select].Quantity == 1)
                {
                    item.Quantity = 1;
                    item.IsBought = false;

                    // 플레이어 데이터 업데이트 : 장착, 소유아이템, 골드, 아이템 능력치
                    player.UnEquipItem(player.Items[select].ItemId);
                    player.CalcItemStat();
                }
            }
            player.Gold += (int)(player.Items[select].Cost * 0.85f);
            player.RemoveItem(player.Items[select]);

            return ResponseCode.SELLCOMPLETE;
        }

    }
}
