using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace textdungeon.Play
{
    // 4주차 과제 응용
    public interface ICharacter
    {
        public string Name { get; }
        public int AttPow { get; }
        public int Health { get; }

        // 몬스터의 경우 드랍 골드의 기준치
        public int Gold { get; }

        public int Level { get; }

        bool IsDead { get; }

        void TakeDamage(int damage);
    }
}
