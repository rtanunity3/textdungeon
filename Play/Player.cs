using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Equipment
    {
        public int Head { get; set; }
        public int Body { get; set; }
        public int Weapon { get; set; }
        public int Shield { get; set; }
    }

    public class Player
    {
        public string Name { get; set; }
        public int AttPow { get; set; }
        public int ItemAttPow { get; set; }
        public int DefPow { get; set; }
        public int ItemDefPow { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
        public int DisplayExp { get; set; }
        public Equipment Equipped { get; set; }
        public List<Item> Items { get; set; } = new List<Item>() { new Item(false, false, 0, 0, 0, "", "", 0) };

        int[] itemTableColWidth = { 25, 40, 55, 110 };
        int itemInfoTableTop = 4;
        int maxLevel = 10;

        public Player(string name)
        {
            Name = name;
            AttPow = 10;
            DefPow = 5;
            Health = 100;
            Gold = 1500;
            Level = 1;
            Exp = 0;
            DisplayExp = 0;

            ItemAttPow = 0;
            ItemDefPow = 0;

            Equipped = new Equipment();
        }

        public Player GetPlayer()
        {
            return this;
        }

        public int ItemCount()
        {
            return Items.Count;
        }

        public void DisplayCharacterStatus()
        {
            CalcItemStat();

            Console.Clear();
            Printing.HighlightText("상태 보기", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.: {Level} (Exp:{DisplayExp}/{Level})");
            Printing.HighlightText($"{Name} (전사)\n", ConsoleColor.White);

            Console.Write($"공격력 : {AttPow + ItemAttPow,2}");
            if (ItemAttPow > 0) { Printing.HighlightText($" (+{ItemAttPow,2})", ConsoleColor.Cyan); }
            Console.WriteLine();

            Console.Write($"방어력 : {DefPow + ItemDefPow,2}");
            if (ItemDefPow > 0) { Printing.HighlightText($" (+{ItemDefPow,2})", ConsoleColor.Cyan); }
            Console.WriteLine();

            Console.Write("체 력 : ");
            Printing.HighlightText($"{Health,3}/100\n", ConsoleColor.Red);
            Console.Write("Gold : ");
            Printing.HighlightText($"{Gold} G\n", ConsoleColor.Yellow);
            Console.WriteLine();

            Console.SetCursorPosition(30, 3);
            Printing.HighlightText("착용장비", ConsoleColor.DarkYellow);
            Console.SetCursorPosition(30, 4);
            Console.WriteLine($"투구 : {GetItemName(Equipped.Head)}");
            Console.SetCursorPosition(30, 5);
            Console.WriteLine($"갑옷 : {GetItemName(Equipped.Body)}");
            Console.SetCursorPosition(30, 6);
            Console.WriteLine($"무기 : {GetItemName(Equipped.Weapon)}");
            Console.SetCursorPosition(30, 7);
            Console.WriteLine($"방패 : {GetItemName(Equipped.Shield)}");
            Console.SetCursorPosition(0, 9);

            Console.WriteLine();
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public void DisplayInventory()
        {
            Console.Clear();
            Printing.HighlightText("인벤토리", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Printing.ItemInfoTableTitle(itemTableColWidth, itemInfoTableTop);
            for (int i = 1; i < Items.Count; i++)
            {
                Items[i].ItemInfoWrite(itemTableColWidth, itemInfoTableTop, i, false, false);
            }
            Console.WriteLine();
            Printing.SelectWriteLine(1, "장착 관리");
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public void EquipmentManager()
        {
            Console.Clear();
            Printing.HighlightText("인벤토리 - 장착관리", ConsoleColor.DarkYellow);
            Console.WriteLine();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            Printing.ItemInfoTableTitle(itemTableColWidth, itemInfoTableTop);
            for (int i = 1; i < Items.Count; i++)
            {
                Items[i].ItemInfoWrite(itemTableColWidth, itemInfoTableTop, i, true, false);
            }
            Console.WriteLine();
            Printing.SelectWriteLine(0, "나가기");
            Console.WriteLine();
        }

        public ResponseCode Equipment(int select)
        {
            EquipmentType type = EnumHandler.GetEquipmentType(Items[select].ItemId);

            if (select > 0 && select < Items.Count)
            {
                // 이미 장착한 아이템이면 해제
                if (Items[select].IsEquipped == true)
                {
                    Items[select].IsEquipped = false;
                    switch (type)
                    {
                        case EquipmentType.Head: Equipped.Head = 0; break;
                        case EquipmentType.Body: Equipped.Body = 0; break;
                        case EquipmentType.Weapon: Equipped.Weapon = 0; break;
                        case EquipmentType.Shield: Equipped.Shield = 0; break;
                    }
                    CalcItemStat();
                    return ResponseCode.UNEQUIP;
                }
                else
                {
                    // 착용중인 아이템 해제하고 장착 || 그냥 장착
                    UnEquipTypeItem(type);
                    Items[select].IsEquipped = true;
                    switch (type)
                    {
                        case EquipmentType.Head:
                            Equipped.Head = Items[select].ItemId; break;
                        case EquipmentType.Body:
                            Equipped.Body = Items[select].ItemId; break;
                        case EquipmentType.Weapon:
                            Equipped.Weapon = Items[select].ItemId; break;
                        case EquipmentType.Shield:
                            Equipped.Shield = Items[select].ItemId; break;
                    }
                    CalcItemStat();
                    // 메세지 만들어서 리턴
                    return ResponseCode.EQUIP;
                }
            }
            CalcItemStat();
            return ResponseCode.BADREQUEST;
        }

        public void EquipItemAll()
        {
            foreach (var item in Items)
            {
                if (item.IsEquipped == true)
                {
                    EquipmentType type = EnumHandler.GetEquipmentType(item.ItemId);
                    UnEquipTypeItem(type);
                    item.IsEquipped = true;
                    switch (type)
                    {
                        case EquipmentType.Head:
                            Equipped.Head = item.ItemId; break;
                        case EquipmentType.Body:
                            Equipped.Body = item.ItemId; break;
                        case EquipmentType.Weapon:
                            Equipped.Weapon = item.ItemId; break;
                        case EquipmentType.Shield:
                            Equipped.Shield = item.ItemId; break;
                    }
                }
            }
            CalcItemStat();
        }

        public void UnEquipItem(int itemId)
        {
            foreach (var item in Items)
            {
                if (item.ItemId == itemId)
                {
                    item.IsEquipped = false;
                }
            }
            if (Equipped.Head == itemId)
            {
                Equipped.Head = 0;
            }
            else if (Equipped.Body == itemId)
            {
                Equipped.Body = 0;
            }
            else if (Equipped.Weapon == itemId)
            {
                Equipped.Weapon = 0;
            }
            else if (Equipped.Shield == itemId)
            {
                Equipped.Shield = 0;
            }
        }

        public void UnEquipTypeItem(EquipmentType type)
        {
            switch (type)
            {
                case EquipmentType.Head:
                    foreach (var item in Items)
                    {
                        if (item.ItemId > 1000 && item.ItemId <= 2000)
                        {
                            item.IsEquipped = false;
                        }
                    }
                    break;
                case EquipmentType.Body:
                    foreach (var item in Items)
                    {
                        if (item.ItemId > 2000 && item.ItemId <= 3000)
                        {
                            item.IsEquipped = false;
                        }
                    }
                    break;
                case EquipmentType.Weapon:
                    foreach (var item in Items)
                    {
                        if (item.ItemId > 3000 && item.ItemId <= 4000)
                        {
                            item.IsEquipped = false;
                        }
                    }
                    break;
                case EquipmentType.Shield:
                    foreach (var item in Items)
                    {
                        if (item.ItemId > 4000 && item.ItemId <= 5000)
                        {
                            item.IsEquipped = false;
                        }
                    }
                    break;
            }
        }

        public string GetItemName(int itemId)
        {
            foreach (var item in Items)
            {
                if (item.ItemId == itemId)
                {
                    return item.Name;
                }
            }
            return " - ";
        }

        public void CalcItemStat()
        {
            ItemAttPow = 0;
            ItemDefPow = 0;

            foreach (var item in Items)
            {
                if (item.IsEquipped)
                {
                    ItemAttPow += item.ItemAttPow;
                    ItemDefPow += item.ItemDefPow;
                }
            }
        }

        public void CalcLevel()
        {
            int tmpExp = Exp;
            int tmpLevel = 0;
            // 경험치로 레벨set
            for (int i = 0; i < maxLevel; i++)
            {
                if (tmpExp >= i)
                {
                    tmpExp -= i;
                    tmpLevel++;
                }
            }

            DisplayExp = tmpExp;
            Level = tmpLevel;
            // 레벨 기준 공방 업데이트
            AttPow = 10 + (int)((Level - 1) * 0.5); // 소수점은 버림
            DefPow = 5 + (Level - 1);
        }

        public void AddExp(int exp)
        {
            Exp += exp;
            CalcLevel();
        }

        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Player Deserialize(string jsonData)
        {
            return JsonSerializer.Deserialize<Player>(jsonData);
        }


    }
}
