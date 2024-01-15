using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Kobold : Monster
    {
        //TODO 아래의 모든몬스터 설정해야합니다.
        public Kobold(int level) : base("코볼트", 10, 5, 100, level, 1, 0, 1)
        {
            //TODO 몬스터별로 다르게 설정해줘야함
            PlusAttPow = 2;
            PlusHealth = 5;
            PlusGold = 50;
            // 현재 들어가있는 스탯들은 기본스탯, 레벨이 증가하면 기본스탯에 플러스가 되도록
            LevelScailing(level);
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
        public Goblin(int level) : base("고블린", 20, 7, 120, level, 2, 0, 2)
        {
            PlusAttPow = 2;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Hobgoblin(int level) : base("홉고블린", 50, 10, 150, level, 3, 0, 4)
        {
            PlusAttPow = 3;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Zombie(int level) : base("좀비", 20, 5, 150, level, 4, 0, 1)
        {
            PlusAttPow = 2;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Ghost(int level) : base("고스트", 20, 10, 150, level, 5, 0, 2)
        {
            PlusAttPow = 2;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Ghoul(int level) : base("구울", 40, 8, 300, level, 6, 0, 3)
        {
            PlusAttPow = 2;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Banshee(int level) : base("밴시", 30, 10, 250, level, 7, 0, 3)
        {
            PlusAttPow = 2;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Skeleton(int level) : base("스켈레톤", 35, 8, 250, level, 8, 0, 4)
        {
            PlusAttPow = 2;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Undine(int level) : base("운디네", 35, 10, 250, level, 9, 0, 6)
        {
            PlusAttPow = 3;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
    
    public class Sylph : Monster
    {
        public Sylph(int level) : base("실프", 35, 10, 250, level, 9, 0, 6)
        {
            PlusAttPow = 3;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
    public class Salamandra : Monster
    {
        public Salamandra(int level) : base("살라만드라", 35, 10, 250, level, 11, 0, 6)
        {
            PlusAttPow = 3;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Gnome(int level) : base("노움", 35, 10, 250, level, 12, 0, 6)
        {
            PlusAttPow = 3;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Troll(int level) : base("트롤", 100, 12, 350, level, 13, 0, 15)
        {
            PlusAttPow = 3;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Orc(int level) : base("오크", 100, 12, 350, level, 14, 0, 15)
        {
            PlusAttPow = 3;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Ogre(int level) : base("오우거", 100, 10, 350, level, 15, 0, 15)
        {
            PlusAttPow = 3;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public OgreMage(int level) : base("오우거메이지", 70, 14, 350, level, 16, 0, 17)
        {
            PlusAttPow = 3;
            PlusHealth = 5;
            PlusGold = 50;
            LevelScailing(level);
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
        public Unicon(int level) : base("유니콘", 150, 20, 500, level, 17, 0, 30)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
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
        public Titan(int level) : base("타이탄", 250, 25, 600, level, 18, 0, 45)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
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
        public Dragon(int level) : base("드래곤", 300, 30, 800, level, 19, 0, 60)
        {
            PlusAttPow = 5;
            PlusHealth = 10;
            PlusGold = 50;
            LevelScailing(level);
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