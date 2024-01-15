using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using textdungeon.Screen;

namespace textdungeon.Play
{
    public class Monster : ICharacter
    {
        public string Name { get; }
        public int AttPow { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public int Level { get; }
        public int ID { get; }
        public int UniqueID { get; }
        public bool IsDead => Health <= 0;
        public string ToStringName => $"Lv.{Level} {Name}";
        public int GiveExp { get; set; }
        public string ToStringEnemie => $"{ToStringName} {(IsDead ? "Dead" : $"HP {Health}")}";
        
        public int PlusAttPow { get; set; }
        public int PlusHealth { get; set; }
        public int PlusGold { get; set; } // TODO 보상골드를 랜덤값으로 설정할수있도록 수정

        public Monster(string name, int health, int attPow, int gold, int level, int id, int uniqueID, int giveexp)
        {
            Name = name;
            Health = health;
            AttPow = attPow;
            Gold = gold;
            Level = level;
            ID = id;
            UniqueID = uniqueID;
            GiveExp = giveexp;
            PlusAttPow = 0;
            PlusHealth = 0;
            PlusGold = 0;
        }

        //public void TakeDamage(SkillType skillType, int damage)
        //{
        //    Health = Math.Max(Math.Min((Health - damage), 100), 0);
        //}

        public void LevelScailing(int level) 
        {
            //레벨에따라 추가되는스탯
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }
        
    }
}
