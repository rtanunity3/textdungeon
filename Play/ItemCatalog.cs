using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using textdungeon.Screen;

namespace textdungeon.Play
{
    // 아이템 정보 저장
    public class NoviceHelmet : Item
    {
        public NoviceHelmet() : base(false, false, 1001, 0, 1, "수련자 투구", "수련에 도움을 주는 투구입니다.", 1000) { }
    }

    public class IronHelmet : Item
    {
        public IronHelmet() : base(false, false, 1002, 0, 2, "무쇠 투구", "무쇠로 만들어져 튼튼한 투구입니다.", 2000) { }
    }

    public class SpartanHelmet : Item
    {
        public SpartanHelmet() : base(false, false, 1003, 0, 4, "스파르타의 투구", "스파르타의 전사들이 사용했다는 전설의 투구입니다.", 3500) { }
    }

    public class NoviceArmor : Item
    {
        public NoviceArmor() : base(false, false, 2001, 0, 5, "수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 1000) { }
    }

    public class IronArmor : Item
    {
        public IronArmor() : base(false, false, 2002, 0, 9, "무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000) { }
    }

    public class SpartanArmor : Item
    {
        public SpartanArmor() : base(false, false, 2003, 0, 15, "스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500) { }
    }

    public class OldSword : Item
    {
        public OldSword() : base(false, false, 3001, 4, 0, "낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 1000) { }
    }

    public class BronzeAxe : Item
    {
        public BronzeAxe() : base(false, false, 3002, 8, 0, "청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 2000) { }
    }

    public class SpartanSpear : Item
    {
        public SpartanSpear() : base(false, false, 3003, 16, 0, "스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3500) { }
    }

    public class OldShield : Item
    {
        public OldShield() : base(false, false, 4001, 1, 2, "낡은 방패", "쉽게 볼 수 있는 낡은 방패 입니다.", 1000) { }
    }

    public class BronzeShield : Item
    {
        public BronzeShield() : base(false, false, 4002, 2, 5, "청동 방패", "어디선가 사용됐던거 같은 방패입니다.", 2000) { }
    }

    public class SpartanShield : Item
    {
        public SpartanShield() : base(false, false, 4003, 3, 9, "스파르타의 방패", "스파르타의 전사들이 사용했다는 전설의 방패입니다.", 3500) { }
    }

    // 소모품
    public abstract class ConsumableItem : Item
    {
        public ConsumableItem(bool isEquipped, bool isBought, int itemId, int itemAttPow, int itemDefPow, string name, string desc, int cost, int quantity = 1) : base(isEquipped, isBought, itemId, itemAttPow, itemDefPow, name, desc, cost, quantity) { }

        public abstract bool UseItem(Player player);
    }

    public class HealingPotion : ConsumableItem
    {
        public int HealingAmount { get; set; }

        public HealingPotion(int quantity = 1, int healingAmount = 30) : base(false, false, 5001, 0, 0, "힐링 포션", $"체력을 {healingAmount} 회복 시켜주는 물약입니다.", 100, quantity)
        {
            HealingAmount = healingAmount;
        }

        public override bool UseItem(Player player)
        {
            player.Health += HealingAmount;
            if (player.Health > 100)
                player.Health = 100;

            Quantity -= 1;
            if (Quantity <= 0)
                return true;
            else 
                return false;
        }
    }
}
