using textdungeon.Screen;

namespace textdungeon.Play
{
    // 직업에 맞춘 아이템 지급을 위한 static 코드.
    //NOTE GetLowTierItem(enum CharacterClass.type) 을 사용하여 직업별 아이템을 받아 올 수 있음.
    //NOTE 방패의 경우 직업별로 분류되어 있지 않음. CharacterClass.type을 넣지 않고 Method를 불러도 됨.
    public static class ItemManager
    {
        // 헬멧류
        /// <summary>
        /// 캐릭터 직업에 맞춘 Low Tier Helmet 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Helmet</returns>
        public static Item GetLowTierHelmet(CharacterClass playerClass)
        {
            switch (playerClass)
            {
                case CharacterClass.Warrior:
                case CharacterClass.Cleric:
                    return new NoviceHelmet();
                // case CharacterClass.Mage:
                // case CharacterClass.Archer:
                // case CharacterClass.Thief:
                default:
                    return new NoviceHood();
            }
        }

        /// <summary>
        /// 캐릭터 직업에 맞춘 Medium Tier Helmet 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Helmet</returns>
        public static Item GetMediumTierHelmet(CharacterClass playerClass)
        {
            switch (playerClass)
            {
                case CharacterClass.Warrior:
                case CharacterClass.Cleric:
                    return new IronHelmet();
                // case CharacterClass.Mage:
                // case CharacterClass.Archer:
                // case CharacterClass.Thief:
                default:
                    return new NikeHood();
            }
        }

        /// <summary>
        /// 캐릭터 직업에 맞춘 High Tier Helmet 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Helmet</returns>
        public static Item GetHighTierHelmet(CharacterClass playerClass)
        {
            switch (playerClass)
            {
                case CharacterClass.Warrior:
                case CharacterClass.Cleric:
                    return new SpartanHelmet();
                // case CharacterClass.Mage:
                // case CharacterClass.Archer:
                // case CharacterClass.Thief:
                default:
                    return new WhiteHood();
            }
        }

        // 갑옷류
        /// <summary>
        /// 캐릭터 직업에 맞춘 Low Tier Armor 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Armor</returns>
        public static Item GetLowTierArmor(CharacterClass playerClass)
        {
            switch (playerClass)
            {
                case CharacterClass.Warrior:
                case CharacterClass.Cleric:
                    return new NoviceArmor();
                // case CharacterClass.Mage:
                // case CharacterClass.Archer:
                // case CharacterClass.Thief:
                default:
                    return new NoviceRobe();
            }
        }

        /// <summary>
        /// 캐릭터 직업에 맞춘 Medium Tier Armor 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Armor</returns>
        public static Item GetMediumTierArmor(CharacterClass playerClass)
        {
            switch (playerClass)
            {
                case CharacterClass.Warrior:
                case CharacterClass.Cleric:
                    return new IronArmor();
                // case CharacterClass.Thief:
                // case CharacterClass.Mage:
                // case CharacterClass.Archer:
                default:
                    return new ManaRobe();
            }
        }

        /// <summary>
        /// 캐릭터 직업에 맞춘 High Tier Armor 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Armor</returns>
        public static Item GetHighTierArmor(CharacterClass playerClass)
        {
            switch (playerClass)
            {
                case CharacterClass.Warrior:
                case CharacterClass.Cleric:
                    return new SpartanArmor();
                // case CharacterClass.Mage:
                // case CharacterClass.Archer:
                // case CharacterClass.Thief:
                default:
                    return new WhiteRobe();
            }
        }

        // 무기류
        /// <summary>
        /// 캐릭터 직업에 맞춘 Low Tier Weapon 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Weapon</returns>
        public static Item GetLowTierWeapon(CharacterClass playerClass)
        {
            switch (playerClass)
            {
                case CharacterClass.Warrior:
                    return new OldSword();
                case CharacterClass.Cleric:
                    return new OldMace();
                case CharacterClass.Mage:
                    return new NoviceCane();
                case CharacterClass.Archer:
                    return new OldBow();
                case CharacterClass.Thief:
                default:
                    return new OldDagger();
            }
        }

        /// <summary>
        /// 캐릭터 직업에 맞춘 Medium Tier Weapon 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Weapon</returns>
        public static Item GetMediumTierWeapon(CharacterClass playerClass)
        {
            switch (playerClass)
            {
                case CharacterClass.Warrior:
                    return new BronzeAxe();
                case CharacterClass.Cleric:
                    return new MorningStar();
                case CharacterClass.Mage:
                    return new WhiteCane();
                case CharacterClass.Archer:
                    return new CrossBow();
                case CharacterClass.Thief:
                default:
                    return new MagicDagger();
            }
        }

        /// <summary>
        /// 캐릭터 직업에 맞춘 High Tier Weapon 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Weapon</returns>
        public static Item GetHighTierWeapon(CharacterClass playerClass)
        {
            switch (playerClass)
            {
                case CharacterClass.Warrior:
                    return new SpartanSpear();
                case CharacterClass.Cleric:
                    return new WarHammer();
                case CharacterClass.Mage:
                    return new PastoralOakCane();
                case CharacterClass.Archer:
                    return new CompoundBow();
                case CharacterClass.Thief:
                default:
                    return new KrisDagger();
            }
        }

        // 방패류
        /// <summary>
        /// Low Tier Shield 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>Shield return</returns>
        public static Item GetLowTierShield()
        {
            return new OldShield();
        }

        /// <summary>
        /// Medium Tier Shield 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>Shield return</returns>
        public static Item GetMediumTierShield()
        {
            return new BronzeShield();
        }

        /// <summary>
        /// High Tier Shield 지급.
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>Shield return</returns>
        public static Item GetHighTierShield()
        {
            return new SpartanShield();
        }

        /// <summary>
        /// 직업에 맞춘 상점 인벤토리 초기화 용 Method. 
        /// </summary>
        /// <param name="playerClass"></param>
        /// <returns>직업에 맞춘 Item List return</returns>
        public static List<Item> GetStoreInventory(CharacterClass playerClass)
        {
            var ItemList = new List<Item>()
            {
                new Item(false, false, 0, 0, 0, "", "", 0),
                new HealingPotion(),
                new ManaPotion(),
                new PowerPotion(),
                GetLowTierHelmet(playerClass),
                GetMediumTierHelmet(playerClass),
                GetHighTierHelmet(playerClass),
                GetLowTierArmor(playerClass),
                GetMediumTierArmor(playerClass),
                GetHighTierArmor(playerClass),
                GetLowTierWeapon(playerClass),
                GetMediumTierWeapon(playerClass),
                GetHighTierWeapon(playerClass),
                GetLowTierShield(),
                GetMediumTierShield(),
                GetHighTierShield()
            };

            return ItemList;
        }
    }
}
