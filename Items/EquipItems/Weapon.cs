using GamePrototype.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace GamePrototype.Items.EquipItems
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
