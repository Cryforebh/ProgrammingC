using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Utils;
using System.Dynamic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace GamePrototype.Units
{
    public sealed class Player : Unit
    {
        private readonly Dictionary<EquipSlot, EquipItem> _equipment = new();

        public Player(string name, uint health, uint maxHealth, uint baseDamage) : base(name, health, maxHealth, baseDamage)
        {            
        }

        public override uint GetUnitDamage()
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var item) && item is Weapon weapon) 
            {
                return BaseDamage + weapon.Damage;
            }
            else if (_equipment.TryGetValue(EquipSlot.Weapon, out var itemrange) && itemrange is RangeWeapon rangeWeapon)
            {
                return BaseDamage + rangeWeapon.Damage;
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
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var itemWeapon) && itemWeapon is Weapon weapon)
                {
                    weapon.Repair();
                }
                if (_equipment.TryGetValue(EquipSlot.Weapon, out var itemRangeWeapon) && itemRangeWeapon is RangeWeapon rangeWeapon)
                {
                    rangeWeapon.Repair();
                }
                if (_equipment.TryGetValue(EquipSlot.Armour, out var itemArmour) && itemArmour is Armour armour)
                {
                    armour.Repair();
                }
                if (_equipment.TryGetValue(EquipSlot.ArmourHelmet, out var itemHelmet) && itemHelmet is ArmourHelmet armourHelmet)
                {
                    itemHelmet.Repair();
                }
            }
        }

        protected override uint CalculateAppliedDamage(uint damage)
        {
            if (_equipment.TryGetValue(EquipSlot.Armour, out var item) && item is Armour armour) 
            {
                if (_equipment.TryGetValue(EquipSlot.ArmourHelmet, out var itemHelmet) && itemHelmet is ArmourHelmet armourHelmet)
                {
                    damage -= (uint)(damage * ((armour.Defence + armourHelmet.Defence) / 100f));
                    armour.ReduceDurability(1); armourHelmet.ReduceDurability(1);
                }
                else
                {
                    damage -= (uint)(damage * (armour.Defence / 100f));
                    armour.ReduceDurability(1);
                }
            }

            return damage;
        }

        public override void CalculateDamageDurability(uint damageDurability)
        {
            if (_equipment.TryGetValue(EquipSlot.Weapon, out var itemWeapon) && itemWeapon is Weapon weapon)
            {
                weapon.ReduceDurability(damageDurability);
            }

            if (_equipment.TryGetValue(EquipSlot.Weapon, out var itemRangeWeapon) && itemRangeWeapon is RangeWeapon rangeWeapon)
            {
                rangeWeapon.ReduceDurability(damageDurability);
            }
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
