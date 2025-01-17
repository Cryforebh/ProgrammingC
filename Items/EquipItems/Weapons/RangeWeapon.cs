using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Items.EquipItems.Weapons
{
    public class RangeWeapon : EquipItem
    {
        public RangeWeapon(uint damage, uint durability, string name) : base(durability, name)
        {
            DamageBase = damage;
            Durability = durability;
        }

        protected uint ProjectileFlightDurationBase { get; set; }
        protected uint DamageBase { get; set; }
        public uint Damage => DamageBase;

        public override EquipSlot Slot => EquipSlot.Weapon;
    }
}
