using GamePrototype.Game.Difficulty;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;
using System.Numerics;

namespace GamePrototype.Utils
{
    public class UnitFactoryDemo
    {
        public UnitFactoryDemo()
        {
        }

        public Difficylty Difficylty = new EasyDifficylty();
        private Unit Player { get; set; }
        public void CreatePlayer(string name)
        {
            
            var player = new Player(name, 30, 30, 3);
            
            player.AddItemToInventory(new Armour(10, 15, "Броня"));
            player.AddItemToInventory(new ArmourHelmet(5, 15, "Шлем"));

            Player = player;
        }

        public Unit CreateWeapon(string name)
        {
            if (name == "0")
            {
                Player.AddItemToInventory(new Sword(4,15));
            }
            if (name == "1")
            {
                Player.AddItemToInventory(new Bow(7, 6));
            }
            return Player;
        }

        public static Unit CreateGoblinEnemy()
        {
            Unit unit = new Goblin(GameConstants.Goblin, 25, 25, 4);
            return unit;
        }
        public static Unit CreateGoblinEnemyTwo() => new Goblin(GameConstants.Goblin, 35, 35, 5);
    }
}
