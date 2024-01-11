namespace textdungeon.Play
{
    public class Monster : ICharacter
    {
        public string Name { get; }
        public int MonsterID {  get; }
        public int AttPow { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; }
        public int Level { get; set; }
        public bool IsDead => Health <= 0;
        public int PlusAttPow { get; set; }
        public int PlusHealth { get; set; }
        public int PlusGold { get; set; } // TODO 보상골드를 랜덤값으로 설정할수있도록 수정

        public Monster(string name, int monsterid, int health, int attPow, int gold, int level)
        {
            Name = name;
            MonsterID = monsterid;
            Health = health;
            AttPow = attPow;
            Gold = gold;
            Level = level;
            PlusAttPow = 0;
            PlusHealth = 0;
            PlusGold = 0;
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(Math.Min((Health - damage), 100), 0);
        }
        public virtual void LevelScailing(int level) { }
    }
}
