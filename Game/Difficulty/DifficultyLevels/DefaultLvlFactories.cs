using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;
using static GamePrototype.Utils.HardDungeonBuilder;

namespace GamePrototype.Game.Difficulty.DifficultyLevels
{
    public class DefaultLvlFactories : DifficyltyFactory
    {
        public DefaultLvlFactories()
        {
            NameDifficylty = "Средний уровень сложности";
        }

        public override Unit CreatePlayer(string name)
        {
            if (name == null) name = "Игрок";

            var player = Player = new Player(name, 25, 25, 3);
            return Player;
        }

        public static Unit CreateGoblinEnemy()
        {
            Unit unit = new Goblin(GameConstants.Goblin, 25, 25, 4);
            return unit;
        }

        public static Unit CreateGoblinEnemy(uint rank)
        {
            Unit unit;
            switch (rank)
            {
                case 0:
                    unit = new Goblin(GameConstants.Goblin, 25, 25, 3);
                    break;
                case 1:
                    unit = new Goblin(GameConstants.Goblin, 35, 35, 5);
                    break;
                default:
                    unit = new Goblin(GameConstants.Goblin, 25, 25, 3);
                    break;
            }
            return unit;
        }

        public override DungeonRoom CreateDungeon()
        {
            DungeonFactory defaultDungeonBuilder = new DefaultDungeonBuilder();
            return defaultDungeonBuilder.BuildDungeon();
        }
    }
}
