using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Items.EquipItems.Weapons;

namespace GamePrototype.Units
{
    public abstract class Unit
    {
        private const int INVENTORY_SIZE = 3;
        private uint _health;
        private uint _maxHealth;
        protected uint BaseDamage;
        protected Inventory Inventory;

        public string Name { get; private set; }
        public uint Health
        {
            get => _health;
            protected set => _health = value;
        }

        public uint MaxHealth => _maxHealth;

        private uint _damageDurability = 1;
        public uint DamageDurability => _damageDurability;

        private uint _lastDamage { get; set; }
        public uint LastDamage => _lastDamage;

        protected Unit(string name, uint health, uint maxHealth, uint baseDamage)
        {

            Name = name;
            _health = health;
            _maxHealth = maxHealth;
            BaseDamage = baseDamage;
            Inventory = new Inventory(INVENTORY_SIZE);
        }

        public void ApplyDamage(uint damage)
        {
            var damageApplied = CalculateAppliedDamage(damage, _damageDurability);
            if (_health < damageApplied || (_health - damageApplied) <= 0)
            {
                _health = 0;
            }
            else
            {
                _health -= damageApplied;
            }

            DamageReceiveHandler();
        }

        protected abstract uint CalculateAppliedDamage(uint damage, uint damageDurability);

        public abstract uint CalculateDamageDurability(uint damageDurability);

        protected virtual void DamageReceiveHandler() { }

        public abstract uint GetUnitDamage();

        public abstract void HandleCombatComplete();

        public virtual void AddItemToInventory(Item item)
        {
            if (!Inventory.TryAdd(item))
            {
                Console.WriteLine($"В инветраре {Name} заполненно.");
            }
        }

        public void AddItemsFromUnitToInventory(Unit unit)
        {
            for (int i = 0; i < unit.Inventory.Items.Count; i++)
            {
                if (!Inventory.TryAdd(unit.Inventory.Items[i]))
                {
                    //inventory is full
                    return;
                }
            }
        }

        public uint GetDamage(EquipItem equipItem)
        {
            if (equipItem is Weapon weapon)
            {
                _lastDamage = weapon.Damage + BaseDamage;
                return _lastDamage;
            }
            if (equipItem is RangeWeapon rangeWeapon)
            {
                _lastDamage = rangeWeapon.Damage + BaseDamage;
                return _lastDamage;
            }
            _lastDamage = BaseDamage;
            return BaseDamage;
        }

        public void InfoDamage()
        {
            Console.WriteLine($"Последний нанесенный урон - {LastDamage}");
        }
    }
}
