using GamePrototype.Utils;

namespace GamePrototype.Items.EquipItems.Armors
{
    public abstract class ArmourHelmet : EquipItem
    {
        public ArmourHelmet(uint defence, uint durability, string name) : base(durability, name)
        {
            Defence = defence;
            Durability = durability;
        }

        public uint Defence { get; }

        public override EquipSlot Slot => EquipSlot.ArmourHelmet;
    }
}
