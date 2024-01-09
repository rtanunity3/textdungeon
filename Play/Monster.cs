using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textdungeon.Play
{
    public class Monster : ICharacter
    {
        public string Name { get; }
        public int AttPow { get; }
        public int Health { get; set; }
        public int Gold { get; }
        public int Level { get; }
        public bool IsDead => Health <= 0;

        public Monster(string name, int health, int attPow, int gold, int level)
        {
            Name = name;
            Health = health;
            AttPow = attPow;
            Gold = gold;
            Level = level;
        }

        public void TakeDamage(int damage)
        {
            Health = Math.Max(Math.Min((Health - damage), 100), 0);
        }
    }

    public class Goblin : Monster
    {
        public Goblin(string name, int health, int attack, int gold, int level) : base(name, health, attack, gold, level) { }
    }
    public class Dragon : Monster
    {
        public Dragon(string name, int health, int attack, int gold, int level) : base(name, health, attack, gold, level) { }
    }
}
