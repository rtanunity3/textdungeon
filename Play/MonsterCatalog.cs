using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace textdungeon.Play
{
    public class kobold : Monster
    {
        //TODO 아래의 모든몬스터 설정해야합니다.
        public kobold(int level) : base("코볼트", 1, 5, 10, 100, level) 
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
    }
    public class Goblin : Monster
    {
        public Goblin(int level) : base("고블린", 2, 15, 20, 120, level)
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
    }
    public class Hobgoblin : Monster
    {
        public Hobgoblin(int level) : base("홉고블린", 3, 30, 50, 150, level)
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
    }
    public class Zombie : Monster
    {
        public Zombie(int level) : base("좀비", 4, 20, 20, 150, level)
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
    }
    public class Ghost : Monster
    {
        public Ghost(int level) : base("고스트", 5, 20, 20, 150, level)
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
    }
    public class Ghoul : Monster
    {
        public Ghoul(int level) : base("구울", 6, 35, 40, 300, level)
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
    }
    public class Banshee : Monster
    {
        public Banshee(int level) : base("밴시", 7, 40, 30, 250, level)
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
    }
    public class Skeleton : Monster
    {
        public Skeleton(int level) : base("스켈레톤", 8, 30, 35, 250, level)
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
    }
    public class Undine : Monster
    {
        public Undine(int level) : base("운디네", 9, 35, 35, 250, level)
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
    }
    public class sylph : Monster
    {
        public sylph(int level) : base("실프", 10, 35, 35, 250, level)
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
    }
    public class salamandra : Monster
    {
        public salamandra(int level) : base("실프", 11, 35, 35, 250, level)
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
    }
    public class Gnome : Monster
    {
        public Gnome(int level) : base("노움", 12, 35, 35, 250, level)
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
    }
    public class Troll : Monster
    {
        public Troll(int level) : base("트롤", 13, 100, 70, 350, level)
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
    }
    public class Orc : Monster
    {
        public Orc(int level) : base("오크", 14, 100, 70, 350, level)
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
    }
    public class Ogre : Monster
    {
        public Ogre(int level) : base("오우거", 15, 100, 70, 350, level)
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
    }
    public class OgreMage : Monster
    {
        public OgreMage(int level) : base("오우거메이지", 16, 100, 70, 350, level)
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
    }
    public class Unicon : Monster
    {
        public Unicon(int level) : base("유니콘", 17, 200, 150, 500, level)
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
    }
    public class Titan : Monster
    {
        public Titan(int level) : base("타이탄", 18, 250, 200, 600, level)
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
    }
    public class Dragon : Monster
    {
        public Dragon(int level) : base("드래곤", 19, 300, 300, 800, level)
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
    }

}
