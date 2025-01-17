using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems.Weapons
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
        public Axe() : base(6, 10, "Топор")
        {
        }

        public Axe(uint damage) : this()
        {
            DamageBase = damage;
        }

        public Axe(uint damage, uint durability) : this(damage)
        {
            Durability = durability;
        }
    }
}
