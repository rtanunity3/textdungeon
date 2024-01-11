using textdungeon.Screen;
using System.Text.Json.Serialization;

namespace textdungeon.Play
{
    // 직렬화와 역직렬화때, Item class로 업캐스팅된 소모품 아이템들의 type을 명시하기 위함
    //NOTE 첫쨋줄이 없을 경우, 게임 로드 후 ItemCatalog에 여러 장비들이 불러와지지 않음.
    //NOTE 둘쨋줄이 없을 경우, 게임 로드 후 HealingPotion이 불러와지지 않음.
    //HOTE 다른 소모품을 추가할 경우, 둘쨋줄을 복사하여 tpyeof와 typeDiscriminator를 수정하면 추가 가능.
    [JsonPolymorphic(UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType)]
    [JsonDerivedType(typeof(HealingPotion), typeDiscriminator: "consumable")]
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
        5001~6000 : 소모품
        */
        public int ItemId { get; }
        public int ItemAttPow { get; }
        public int ItemDefPow { get; }

        public string Name { get; }
        public string Desc { get; }

        public int Cost { get; }
        // 수량
        public int Quantity { get; set; }

        public Item(bool isEquipped, bool isBought, int itemId, int itemAttPow, int itemDefPow, string name, string desc, int cost, int quantity = 1)
        {
            IsEquipped = isEquipped;
            IsBought = isBought;
            ItemId = itemId;
            ItemAttPow = itemAttPow;
            ItemDefPow = itemDefPow;
            Name = name;
            Desc = desc;
            Cost = cost;
            Quantity = quantity;
        }

        // 플레이어 인벤토리에 아이템을 추가할 때, Item 객체를 복사하기 위함.
        public object DeepCopy()
        {
            return MemberwiseClone();
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
                    Printing.HighlightText($"{Cost} G", boughtColor);
                }
                else
                {
                    Printing.HighlightText($"{Cost} G", ConsoleColor.Yellow);
                }
            }
            else if (isSell)
            {
                Printing.HighlightText($"{Cost * 0.85} G", ConsoleColor.Yellow);
            }
            else
            {
                // 인벤토리에서의 아이템 수량 표시 부분.
                Printing.HighlightText($"{Quantity}\n", ConsoleColor.Yellow);
            }

            // 상점에서의 아이템 수량 표시 부분.
            Console.SetCursorPosition(itemTableColWidth[4], defaultHeight + i);
            if (isSale)
            {
                Console.Write($"| ");
                if (IsBought)
                {
                    Printing.HighlightText($"{Quantity}\n", boughtColor);
                }
                else
                {
                    EquipmentType type = EnumHandler.GetEquipmentType(ItemId);
                    if(type != EquipmentType.Consumable)
                        Printing.HighlightText($"{Quantity}\n", ConsoleColor.Yellow);
                    else
                        Printing.HighlightText("∞\n", ConsoleColor.Yellow);
                }
            }
            else if (isSell)
            {
                Console.Write($"| ");
                Printing.HighlightText($"{Quantity}\n", ConsoleColor.Yellow);
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}
