using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems
{

    public sealed class Sword : Weapon
    {
        public Sword() : base(4, 15, "Меч")
        {
        }

        public Sword(uint damage) : this() 
        {
            DamageBase = damage;
        }

        public Sword(uint damage, uint durability) : this(damage)
        {
            Durability = durability;
        }
    }

    public sealed class Axe : Weapon
    {
        public Axe(uint damage, uint durability) : base(damage, durability, "Топор")
        {
            DamageBase = damage;
        }
    }
}
