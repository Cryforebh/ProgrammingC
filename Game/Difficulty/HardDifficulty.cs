using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Game.Difficulty
{
    public class HardDifficulty : Difficulty
    {
        public HardDifficulty(uint health)
        {
            Console.WriteLine("Высокая сложность.");
            Health = health - health / 4;
            MaxHealth = health;
        }

        public HardDifficulty(uint health, uint baseDamage) : this(health)
        {
            BaseDamage = baseDamage - baseDamage/2;
        }

        public uint Health { get; }
        public uint MaxHealth { get; }
        public uint BaseDamage { get; }
    }
}
