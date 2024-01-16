namespace textdungeon.Play
{
    // 아이템 정보 저장
    // 헬멧류
    // 전사, 성직자 헬멧
    public class NoviceHelmet : Item { public NoviceHelmet()
            : base(false, false, 1001, 0, 1, "수련자 투구", "수련에 도움을 주는 투구입니다.", 1000) { } }

    public class IronHelmet : Item { public IronHelmet() 
            : base(false, false, 1002, 0, 2, "무쇠 투구", "무쇠로 만들어져 튼튼한 투구입니다.", 2000) { } }

    public class SpartanHelmet : Item { public SpartanHelmet() 
            : base(false, false, 1003, 0, 4, "스파르타의 투구", "스파르타의 전사들이 사용했다는 전설의 투구입니다.", 3500) { } }

    // 마법사, 도적, 궁수 헬멧
    public class NoviceHood : Item { public NoviceHood() 
            : base(false, false, 1004, 0, 1, "수련자 후드", "수련에 도움을 주는 후드입니다.", 1000) { } }

    public class NikeHood : Item { public NikeHood() 
            : base(false, false, 1005, 0, 2, "나이키 후드", "명장 나이키가 만든 후드입니다.", 2000) { } }
    
    public class WhiteHood : Item { public WhiteHood() 
            : base(false, false, 1006, 0, 4, "백색 후드", "왠지 모르겠지만 이걸 입으면 멋질 것 같습니다.", 3500) { } }

    // 갑옷류
    // 전사, 성직자 갑옷
    public class NoviceArmor : Item { public NoviceArmor() 
            : base(false, false, 2001, 0, 5, "수련자 갑옷", "수련에 도움을 주는 갑옷입니다.", 1000) { } }

    public class IronArmor : Item { public IronArmor() 
            : base(false, false, 2002, 0, 9, "무쇠 갑옷", "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000) { } }

    public class SpartanArmor : Item { public SpartanArmor() 
            : base(false, false, 2003, 0, 15, "스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500) { } }

    // 마법사, 도적, 궁수 갑옷
    public class NoviceRobe : Item { public NoviceRobe() 
            : base(false, false, 2004, 0, 5, "수련자 로브", "수련에 도움을 주는 로브입니다.", 1000) { } }

    public class ManaRobe : Item { public ManaRobe() 
            : base(false, false, 2005, 0, 9, "마력의 로브", "마력회복에 도움이 된다고 홍보하는 로브입니다.", 2000) { } }
    
    public class WhiteRobe : Item { public WhiteRobe() 
            : base(false, false, 2006, 0, 15, "백색 로브", "왠지 모르겠지만 이걸 입으면 자신감이 생깁니다.", 3500) { } }

    // 무기류
    //NOTE 전사 무기
    public class OldSword : Item { public OldSword() 
            : base(false, false, 3001, 4, 0, "낡은 검", "쉽게 볼 수 있는 낡은 검 입니다.", 1000) { } }

    public class BronzeAxe : Item { public BronzeAxe() 
            : base(false, false, 3002, 8, 0, "청동 도끼", "어디선가 사용됐던거 같은 도끼입니다.", 2000) { } }

    public class SpartanSpear : Item { public SpartanSpear() 
            : base(false, false, 3003, 16, 0, "스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 3500) { } }

    //NOTE 마법사 무기
    public class NoviceCane : Item { public NoviceCane() 
            : base(false, false, 3004, 4, 0, "초보자의 지팡이", "마법에 입문한 자들이 사용하는 지팡이입니다.", 1000) { } }

    public class WhiteCane : Item { public WhiteCane() 
            : base(false, false, 3005, 8, 0, "하얀 지팡이", "하얀색의 깔끔한 지팡이입니다.", 2000) { } }
    
    public class PastoralOakCane : Item { public PastoralOakCane() 
            : base(false, false, 3006, 16, 0, "떡갈나무 지팡이", "모든 마법사들이 원하는 떡갈나무 지팡이입니다.", 3500) { } }

    //NOTE 도적 무기
    public class OldDagger : Item { public OldDagger()
            : base(false, false, 3007, 4, 0, "낡은 단검", "오래 쓸 수 없을 것 같은 단검입니다.", 1000) { } }

    public class MagicDagger : Item { public MagicDagger() 
            : base(false, false, 3008, 8, 0, "마법 단검", "마법이 부여되어 있다는 소문의 단검입니다.", 2000) { } }

    public class KrisDagger : Item { public KrisDagger() 
            : base(false, false, 3009, 16, 0, "크리스 단검", "물결무늬의 날이 특징인 날카로운 단검입니다.", 3500) { } }
    
    //NOTE 궁수 무기
    public class OldBow : Item { public OldBow() 
            : base(false, false, 3010, 4, 0, "낡은 활", "곧장 부러질 것 같은 낡은 활입니다.", 1000) { } }
    
    public class CrossBow : Item { public CrossBow() 
            : base(false, false, 3011, 8, 0, "석궁", "깔끔한 제식 석궁입니다.", 2000) { } }
    
    public class CompoundBow : Item { public CompoundBow() 
            : base(false, false, 3012, 16, 0, "컴파운드 보우", "알 수 없는 기술이 적용된 강력한 활입니다.", 3500) { } }
    
    //NOTE 성직자 무기
    public class OldMace : Item { public OldMace() 
            : base(false, false, 3013, 4, 0, "낡은 메이스", "자루가 썩어 오래 쓸 수 없고 녹이 슨 메이스입니다.", 1000) { } }
    
    public class MorningStar : Item { public MorningStar() 
            : base(false, false, 3014, 8, 0, "모닝스타", "매우 위협적인 무기인 모닝스타입니다.", 2000) { } }
    
    public class WarHammer : Item { public WarHammer() 
            : base(false, false, 3015, 16, 0, "워해머", "찢고! 죽인다!", 3500) { } }
    
    // 방패류
    public class OldShield : Item { public OldShield() 
            : base(false, false, 4001, 1, 2, "낡은 방패", "쉽게 볼 수 있는 낡은 방패 입니다.", 1000) { } }

    public class BronzeShield : Item { public BronzeShield() 
            : base(false, false, 4002, 2, 5, "청동 방패", "어디선가 사용됐던거 같은 방패입니다.", 2000) { } }

    public class SpartanShield : Item { public SpartanShield() 
            : base(false, false, 4003, 3, 9, "스파르타의 방패", "스파르타의 전사들이 사용했다는 전설의 방패입니다.", 3500) { } }
    
    // 소모품, 확장성을 위한 추상 클래스 구현
    public abstract class ConsumableItem : Item
    {
        public ConsumableItem(bool isEquipped, bool isBought, int itemId, int itemAttPow, int itemDefPow, string name, string desc, int cost, int quantity = 1) 
            : base(isEquipped, isBought, itemId, itemAttPow, itemDefPow, name, desc, cost, quantity) { }

        public abstract bool UseItem(Player player);
    }

    // 힐링 포션
    public class HealingPotion : ConsumableItem
    {
        public int HealingAmount { get; set; }

        public HealingPotion(int quantity = 1, int healingAmount = 30) 
            : base(false, false, 5001, 0, 0, "힐링 포션", $"체력을 {healingAmount} 회복 시켜주는 물약입니다.", 300, quantity)
        {
            HealingAmount = healingAmount;
        }

        public override bool UseItem(Player player)
        {
            player.Health += HealingAmount;
            if (player.Health > player.MaxHealth)
                player.Health = player.MaxHealth;

            Quantity -= 1;
            if (Quantity <= 0)
                return true;
            else 
                return false;
        }
    }

    // 마나 포션
    public class ManaPotion : ConsumableItem
    {
        public int ManaRecoveryAmount { get; set; }

        public ManaPotion(int quantity = 1, int manaRecoveryAmount = 15) 
            : base(false, false, 5002, 0, 0, "마나 포션", $"마나를 {manaRecoveryAmount} 회복 시켜주는 물약입니다.", 300, quantity)
        {
            ManaRecoveryAmount = manaRecoveryAmount;
        }

        public override bool UseItem(Player player)
        {
            player.Mana += ManaRecoveryAmount;
            if(player.Mana > player.MaxMana)
                player.Mana = player.MaxMana;

            Quantity -= 1;
            if (Quantity <= 0)
                return true;
            else
                return false;
        }
    }

    // 파워 포션
    public class PowerPotion : ConsumableItem
    {
        public int IncreaseAmount;

        public PowerPotion(int quantity = 1, int increaseAmount = 5) 
            : base(false, false, 5003, 0, 0, "파워 포션", $"공격력을 영구적으로 {increaseAmount} 올려주는 물약입니다.", 20000, quantity)
        {
            IncreaseAmount = increaseAmount;
        }

        public override bool UseItem(Player player)
        {
            player.AttPow += IncreaseAmount;

            Quantity -= 1;
            if (Quantity <= 0)
                return true;
            else
                return false;
        }
    }
}
