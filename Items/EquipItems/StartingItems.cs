using GamePrototype.Items.EquipItems.Armors;
using GamePrototype.Items.EquipItems.Weapons;
using GamePrototype.Units;

namespace GamePrototype.Items.EquipItems
{
    public class StartingItems
    {
        public StartingItems()
        {
        }

        public Unit SetArmor(Unit player)
        {
            EquipItem[] _equipItemsArmour = { new IronArmor(), new SteelArmor() };
            EquipItem[] _equipItemsHelmet = { new IronHelmet(), new SteelHelmet() };
            EquipItem[] _equipItemsWeapon = { new Axe(), new Sword(), new Bow(), new BigBow() };

            Console.WriteLine($"Выбор начального обмундирования...\n");

            ForeachItem(_equipItemsArmour);

            Console.Write($"\nВведи номер брони, которую хочешь получить: ");

            switch (uint.Parse(Console.ReadLine()))
            {
                case 1:
                    player.AddItemToInventory(_equipItemsArmour[0]);
                    break;
                case 2:
                    player.AddItemToInventory(_equipItemsArmour[1]);
                    break;
                default:
                    Console.WriteLine("Данные введены не корректно! Значит останешься без этого предмета!");
                    break;
            }

            Console.WriteLine($"");
            ForeachItem(_equipItemsHelmet);

            Console.Write($"\nВведи номер шлема, который хочешь получить: ");

            switch (uint.Parse(Console.ReadLine()))
            {
                case 1:
                    player.AddItemToInventory(_equipItemsHelmet[0]);
                    break;
                case 2:
                    player.AddItemToInventory(_equipItemsHelmet[1]);
                    break;
                default:
                    Console.WriteLine("Данные введены не корректно! Значит останешься без этого предмета!");
                    break;
            }

            Console.WriteLine($"");
            ForeachItem(_equipItemsWeapon);

            Console.Write($"\nВведи номер оружия, которое хочешь получить: ");

            switch (uint.Parse(Console.ReadLine()))
            {
                case 1:
                    player.AddItemToInventory(_equipItemsWeapon[0]);
                    break;
                case 2:
                    player.AddItemToInventory(_equipItemsWeapon[1]);
                    break;
                case 3:
                    player.AddItemToInventory(_equipItemsWeapon[2]);
                    break;
                case 4:
                    player.AddItemToInventory(_equipItemsWeapon[3]);
                    break;
                default:
                    Console.WriteLine("Данные введены не корректно! Значит останешься без этого предмета!");
                    break;
            }

            Console.WriteLine($"");

            return player;
        }

        private void ForeachItem(EquipItem[] equipItems)
        {
            uint NumberI = 1;
            foreach (var item in equipItems)
            {
                Console.WriteLine($"{NumberI++} - {item.Name}");
            }
        }
    }
}
