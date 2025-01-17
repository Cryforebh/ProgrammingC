using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems.Weapons
{
    public sealed class Bow : RangeWeapon
    {
        public Bow() : base(7, 6, "Лук")
        {
        }

        public Bow(uint damage) : this()
        {
            DamageBase = damage;
        }

        public Bow(uint damage, uint durability) : this(damage)
        {
            Durability = durability;
        }
    }

    public sealed class BigBow : RangeWeapon
    {
        public BigBow() : base(9, 4, "Большой лук")
        {
        }

        public BigBow(uint damage) : this()
        {
            DamageBase = damage;
        }

        public BigBow(uint damage, uint durability) : this(damage)
        {
            Durability = durability;
        }
    }
}
