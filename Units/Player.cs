using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Items.EquipItems.Weapons;
using GamePrototype.Utils;
using System.Text;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {
            Health = health;
        }

        public override uint GetUnitDamage()
        {
            foreach (var item in _equipment.Values)
            {
                if (item is Weapon weapon) return GetDamage(weapon);           
                if (item is RangeWeapon rangeWeapon) return GetDamage(rangeWeapon) ;
            }
            return BaseDamage;
        }

        public override void HandleCombatComplete()
        {
            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i] is EconomicItem economicItem)
                {
                    UseEconomicItem(economicItem);
                    Inventory.TryRemove(items[i]);
                }
            }
        }

        public override void AddItemToInventory(Item item)
        {
            if (item is EquipItem equipItem && _equipment.TryAdd(equipItem.Slot, equipItem))
            {
                // Item was equipped
                return;
            }
            base.AddItemToInventory(item);
        }

        private void UseEconomicItem(EconomicItem economicItem)
        {
            if (economicItem is HealthPotion healthPotion)
            {
                Health += healthPotion.HealthRestore;
            }

            if (economicItem is Grindstone grindstone)
            {
                foreach (var equipment in _equipment.Values)
                {
                    equipment.Repair(grindstone.GrindstoneRestore);
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage, uint damageDurability)
        {
            damage -= (uint)damage * CalculateDamageDurability(damageDurability);

            return damage;
        }

        public override uint CalculateDamageDurability(uint damageDurability)
        {
            uint defence = 0;

            foreach (var equipment in _equipment.Values)
            {
                defence += equipment.Durability;
                equipment.ReduceDurability(damageDurability);
            }

            return defence / 100;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Name);
            builder.AppendLine($"Здоровье {Health}/{MaxHealth}");
            builder.AppendLine("Добыча:");

            var items = Inventory.Items;
            for (int i = 0; i < items.Count; i++)
            {
                builder.AppendLine($"[{items[i].Name}] : {items[i].Amount}");
            }
            return builder.ToString();
        }
    }
}
