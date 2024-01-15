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
        // 아이템 드랍 테이블.
        public ItemDropTable DropTable { get; private set; }

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
            DropTable = new ItemDropTable();
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(Math.Min((Health - damage), 100), 0);
        }

        public void LevelScailing(int level) 
        {
            //레벨에따라 추가되는스탯
            AttPow += (level - 1) * PlusAttPow;
            Health += (level - 1) * PlusHealth;
            Gold += (level - 1) * PlusGold;
        }
        
        // 아이템 드랍 테이블 설정. MonsterCatalog에서 몬스터에 아이템 할당해줌.
        //NOTE new Moster()로 몬스터를 만들어 준 뒤, 설정을 위해 불러줘야함.
        public virtual void SetDropTable(CharacterClass playerClass) { }

        /// <summary>
        /// ItemDropTable에서 Item을 가져오는 Method.
        /// </summary>
        /// <returns>설정된 가중치와 amount로 아이템들 return</returns>
        public List<Item> GetItemReward()
        {
            return DropTable.ItemDrop();
        }
    }
}
