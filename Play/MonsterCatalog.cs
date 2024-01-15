using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Kobold : Monster
    {
        //TODO 아래의 모든몬스터 설정해야합니다.
        public Kobold(int level) : base("코볼트", 10, 5, 100, level, 1, 0)
        {
            //TODO 몬스터별로 다르게 설정해줘야함
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            // 현재 들어가있는 스탯들은 기본스탯, 레벨이 증가하면 기본스탯에 플러스가 되도록
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            //레벨에따라 추가되는스탯
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 6);
            DropTable.AddItem(new ManaPotion(), 4);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 2);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 2);
        }
    }

    public class Goblin : Monster
    {
        public Goblin(int level) : base("고블린", 20, 15, 120, level, 2, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 6);
            DropTable.AddItem(new ManaPotion(), 4);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 2);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 2);
        }
    }

    public class Hobgoblin : Monster
    {
        public Hobgoblin(int level) : base("홉고블린", 50, 30, 150, level, 3, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 8);
            DropTable.AddItem(new ManaPotion(), 5);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 2);
        }
    }

    public class Zombie : Monster
    {
        public Zombie(int level) : base("좀비", 20, 20, 150, level, 4, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 6);
            DropTable.AddItem(new ManaPotion(), 4);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 2);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 2);
        }
    }

    public class Ghost : Monster
    {
        public Ghost(int level) : base("고스트", 20, 20, 150, level, 5, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 6);
            DropTable.AddItem(new ManaPotion(), 4);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 2);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 2);
        }
    }

    public class Ghoul : Monster
    {
        public Ghoul(int level) : base("구울", 40, 35, 300, level, 6, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 8);
            DropTable.AddItem(new ManaPotion(), 5);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 2);
        }
    }

    public class Banshee : Monster
    {
        public Banshee(int level) : base("밴시", 30, 40, 250, level, 7, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 8);
            DropTable.AddItem(new ManaPotion(), 5);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 2);
        }
    }
    public class Skeleton : Monster
    {
        public Skeleton(int level) : base("스켈레톤", 35, 30, 250, level, 8, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 6);
            DropTable.AddItem(new ManaPotion(), 4);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 2);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 2);
        }
    }

    public class Undine : Monster
    {
        public Undine(int level) : base("밴시", 35, 35, 250, level, 9, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 6);
            DropTable.AddItem(new ManaPotion(), 4);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 2);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 2);
        }
    }

    public class sylph : Monster
    {
        public sylph(int level) : base("실프", 35, 35, 250, level, 9, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 6);
            DropTable.AddItem(new ManaPotion(), 4);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 2);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 2);
        }
    }

    public class salamandra : Monster
    {
        public salamandra(int level) : base("실프", 35, 35, 250, level, 11, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 6);
            DropTable.AddItem(new ManaPotion(), 4);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 2);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 2);
        }
    }

    public class Gnome : Monster
    {
        public Gnome(int level) : base("노움", 35, 35, 250, level, 12, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 6);
            DropTable.AddItem(new ManaPotion(), 4);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 2);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 2);
        }
    }

    public class Troll : Monster
    {
        public Troll(int level) : base("트롤", 100, 70, 350, level, 13, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 8);
            DropTable.AddItem(new ManaPotion(), 5);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 2);
        }
    }

    public class Orc : Monster
    {
        public Orc(int level) : base("오크", 100, 70, 350, level, 14, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 8);
            DropTable.AddItem(new ManaPotion(), 5);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 2);
        }
    }

    public class Ogre : Monster
    {
        public Ogre(int level) : base("오우거", 100, 70, 350, level, 15, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 8);
            DropTable.AddItem(new ManaPotion(), 5);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 2);
        }
    }

    public class OgreMage : Monster
    {
        public OgreMage(int level) : base("오우거메이지", 70, 120, 350, level, 16, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(2);
            DropTable.AddItem(new HealingPotion(), 8);
            DropTable.AddItem(new ManaPotion(), 5);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 2);
        }
    }

    public class Unicon : Monster
    {
        public Unicon(int level) : base("유니콘", 150, 200, 500, level, 17, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(3);
            DropTable.AddItem(new HealingPotion(3), 8);
            DropTable.AddItem(new ManaPotion(2), 6);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 5);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 5);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetHighTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetHighTierArmor(playerClass), 2);
        }
    }

    public class Titan : Monster
    {
        public Titan(int level) : base("타이탄", 250, 200, 600, level, 18, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(3);
            DropTable.AddItem(new HealingPotion(3), 8);
            DropTable.AddItem(new ManaPotion(2), 6);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 5);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 5);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetHighTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetHighTierArmor(playerClass), 2);
        }
    }

    public class Dragon : Monster
    {
        public Dragon(int level) : base("드래곤", 300, 300, 800, level, 19, 0)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
        }
        public override void LevelScailing(int level)
        {
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }

        // 아이템 드랍 테이블 설정.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public override void SetDropTable(CharacterClass playerClass)
        {
            DropTable.SetAmount(3);
            DropTable.AddItem(new HealingPotion(3), 8);
            DropTable.AddItem(new ManaPotion(2), 6);
            DropTable.AddItem(ItemManager.GetLowTierArmor(playerClass), 5);
            DropTable.AddItem(ItemManager.GetLowTierWeapon(playerClass), 5);
            DropTable.AddItem(ItemManager.GetMediumTierWeapon(playerClass), 3);
            DropTable.AddItem(ItemManager.GetMediumTierArmor(playerClass), 3);
            DropTable.AddItem(ItemManager.GetHighTierWeapon(playerClass), 2);
            DropTable.AddItem(ItemManager.GetHighTierArmor(playerClass), 2);
        }
    }
}
