using GamePrototype.Dungeon;
using GamePrototype.Game.Difficulty.DifficultyLevels;
using GamePrototype.Units;

namespace GamePrototype.Game.Difficulty
{
    public class InitializeDifficulty
    {

        private DifficyltyFactory _difficyltyFactory;
        private DungeonRoom _dungeon;
        private Unit _player;
        private uint _volue { get; set; }
        public void Initialize()
        {
            Console.Write("Выбери сложность игры (0 - Легко, 1 - Средне, 2 - Тяжело): ");

            switch (uint.Parse(Console.ReadLine()))
            {
                case 0:
                    _difficyltyFactory = new EasyLvlFactories();
                    break;
                case 1:
                    _difficyltyFactory = new DefaultLvlFactories();
                    break;
                case 2:
                    _difficyltyFactory = new HardLvlFactories();
                    break;
                default:
                    Console.WriteLine("Данные указанны не корректно! Установленна средняя сложность.");
                    _difficyltyFactory = new DefaultLvlFactories();
                    break;
            }

            Console.Write("Введи свое имя: ");
            _player = _difficyltyFactory.CreatePlayer(Console.ReadLine());
            _player = _difficyltyFactory.CreateItems();
            _dungeon = _difficyltyFactory.CreateDungeon();
        }

        public DungeonRoom Dungeon => _dungeon;
        public DifficyltyFactory Difficylty => _difficyltyFactory;
        public Unit Player => _player;
    }
}
