using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems.Weapons
{
    public class Weapon : EquipItem
    {
        public Weapon(uint damage, uint durability, string name) : base(durability, name)
        {
            DamageBase = damage;
            Durability = durability;
        }

        protected uint DamageBase { get; set; }
        public uint Damage => DamageBase;
        public override EquipSlot Slot => EquipSlot.Weapon;

        //protected uint LastDamage { get; set; }
        //public uint SetLastDamage(uint lastDamage)
        //{
        //    LastDamage = lastDamage;
        //    return lastDamage;
        //}
    }

}
