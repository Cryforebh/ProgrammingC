using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public class UnitFactoryDemo
    {
        public static Unit CreatePlayer(string name)
        {
            var player = new Player(name, 30, 30, 6);
            player.AddItemToInventory(new Weapon(10, 15, "Меч"));
            player.AddItemToInventory(new Armour(10, 15, "Броня"));
            player.AddItemToInventory(new ArmourHelmet(5, 15, "Шлем"));
            player.AddItemToInventory(new HealthPotion("Зелье здоровья"));
            player.AddItemToInventory(new Grindstone("Точильный камень"));
            return player;
        }

        public static Unit CreateGoblinEnemy() => new Goblin(GameConstants.Goblin, 18, 18, 2);
    }
}
