using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textdungeon
{
    public class Item
    {
        public bool Equipped { get; set; }
        public bool Bought { get; set; }

        /*
        itemId
        1001~2000 : 머리
        2001~3000 : 갑옷
        3001~4000 : 무기
        4001~5000 : 방패
        */
        public uint ItemId { get; set; }
        public int ItemAttPow { get; set; }
        public int ItemDefPow { get; set; }

        public string Name { get; set; }
        public string Desc { get; set; }

        public int Cost { get; set; }

        public Item(bool equipped, bool bought, uint itemId, int itemAttPow, int itemDefPow, string name, string desc, int cost)
        {
            Equipped = equipped;
            Bought = bought;
            ItemId = itemId;
            ItemAttPow = itemAttPow;
            ItemDefPow = itemDefPow;
            Name = name;
            Desc = desc;
            Cost = cost;
        }
    }
}
