using GamePrototype.Dungeon;
using GamePrototype.Items.EquipItems;
using GamePrototype.Units;

namespace GamePrototype.Game.Difficulty
{
    public abstract class DifficyltyFactory
    {
        public string NameDifficylty = "Сложность игры";
        protected uint _value = 1;
        public uint difficyltyValue => _value;

        public Unit Player { get; protected set; }
        protected StartingItems _startingItems = new StartingItems();

        public abstract Unit CreatePlayer(string name);

        public Unit CreateItems()
        {
            return _startingItems.SetArmor(Player);
        }

        public void InfoDifficylty()
        {
            Console.WriteLine(NameDifficylty);
        }

        public abstract DungeonRoom CreateDungeon();
    }
}
