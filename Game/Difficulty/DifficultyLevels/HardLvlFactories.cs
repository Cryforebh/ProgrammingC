using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;

namespace GamePrototype.Game.Difficulty.DifficultyLevels
{
    public class HardLvlFactories : DifficyltyFactory
    {
        public HardLvlFactories()
        {
            NameDifficylty = "Тяжелый уровень сложности";
            _value = 2;
        }

        public override Unit CreatePlayer(string name)
        {
            var player = Player = new Player(name, 15, 15, 2);
            return Player;
        }

        public static Unit CreateGoblinEnemy(uint rank)
        {
            Unit unit;
            switch (rank)
            {
                case 0:
                    unit = new Goblin(GameConstants.Goblin, 35, 35, 4);
                    break;
                case 1:
                    unit = new Goblin(GameConstants.Goblin, 45, 45, 5);
                    break;
                default:
                    unit = new Goblin(GameConstants.Goblin, 35, 35, 4);
                    break;
            }
            return unit;
        }

        public override DungeonRoom CreateDungeon()
        {
            DungeonFactory hardDungeonBuilder = new HardDungeonBuilder();
            return hardDungeonBuilder.BuildDungeon();
        }
    }
}
