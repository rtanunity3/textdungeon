using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace textdungeon
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
        public static Equipment Equipped { get; set; }
        public static List<Item> items;

        public Player()
        {
            Equipped = new Equipment();
            items = new List<Item> { new Item(false, false, 0, 0, 0, "", "", 0) };
        }


        public Player(string name)
        {
            Name = name;
            AttPow = 10;
            DefPow = 5;
            Health = 100;
            Gold = 1500;
            Level = 1;
            Exp = 0;

            ItemAttPow = 0;
            ItemDefPow = 0;

            Equipped = new Equipment();
        }

        public Player GetPlayer()
        {
            return this;
        }

        public void DisplayCharacterStatus()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("상태 보기");
            Console.ResetColor();
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.: {Level}");
            Console.WriteLine($"{Name} (전사)");
            Console.Write($"공격력 : {AttPow}");
            if (ItemAttPow > 0) { Console.WriteLine($"(+{ItemAttPow})"); }
            Console.WriteLine();
            Console.Write($"방어력 : {DefPow}");
            if (ItemDefPow > 0) { Console.WriteLine($"(+{ItemAttPow})"); }
            Console.WriteLine();
            Console.WriteLine($"체 력 : {Health}");
            Console.WriteLine($"Gold : {Gold} G");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("착용장비");
            Console.ResetColor();
            Console.WriteLine($"Head: {Equipped.Head}");
            Console.WriteLine($"Body: {Equipped.Body}");
            Console.WriteLine($"Weapon: {Equipped.Weapon}");
            Console.WriteLine($"Shield: {Equipped.Shield}");
            Console.WriteLine();

            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        public void DisplayInventory()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 1; i < items.Count; i++)
            {
                Console.WriteLine($"{items[i].Name}");
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        public void EquipmentManager()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("인벤토리");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 1; i < items.Count; i++)
            {
                Console.Write(i);
                Console.WriteLine($" {items[i].Name}");
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
        }

        public int Equipment(int select)
        {
            Console.WriteLine($"{select}번쨰 아이템 장착");

            if (select > 0 && select < items.Count)
            {
                // 아이템 정보 생기면 장착/해제/미보유 세가지로 나눔
                return 1;
            }
            return 0;
        }

        public string Serialize()
        {
            return JsonSerializer.Serialize(this);
        }

        public static Player Deserialize(string jsonData)
        {
            return JsonSerializer.Deserialize<Player>(jsonData);

            // 불러와서 장비착용 체크
        }


    }
}
