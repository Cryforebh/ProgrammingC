using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems.Armors
{
    public abstract class Armour : EquipItem
    {
        public Armour(uint defence, uint durability, string name) : base(durability, name)
        {
            Defence = defence;
            Durability = durability;
        }

        public uint Defence { get; }

        public override EquipSlot Slot => EquipSlot.Armour;

    }
}
