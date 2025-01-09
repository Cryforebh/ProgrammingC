using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Game.Difficulty
{
    public class EssyDifficulty : Difficulty
    {
        public EssyDifficulty(uint health, uint baseDamage): this(health)
        {
            BaseDamage = baseDamage;
        }
        private Unit Player { get; set; } 
        public EssyDifficulty(uint health)
        {
            Console.WriteLine("Низкая сложность.");
            Health = health;
            MaxHealth = health + health/4;
        }

        public uint Health { get; }
        public uint MaxHealth { get; }
        public uint BaseDamage { get; }
       
    }
}
