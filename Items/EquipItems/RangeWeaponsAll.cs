using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems
{
    public sealed class Bow : RangeWeapon
    {
        public Bow(uint damage, uint durability) : base(damage, durability, "Лук")
        {
            DamageBase = damage;
        }
    }
}
