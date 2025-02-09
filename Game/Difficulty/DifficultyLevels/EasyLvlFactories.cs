using GamePrototype.Dungeon;
using GamePrototype.Units;
using GamePrototype.Utils;

namespace GamePrototype.Game.Difficulty.DifficultyLevels
{
    public class EasyLvlFactories : DifficyltyFactory
    {
        public EasyLvlFactories()
        {
            NameDifficylty = "Легкий уровень сложности";
            _value = 0;
        }
        public override Unit CreatePlayer(string name)
        {
            var player = Player = new Player(name, 35, 35, 4);
            return Player;
        }

        public static Unit CreateGoblinEnemy(uint rank)
        {
            Unit unit;
            switch (rank)
            {
                case 0:
                    unit = new Goblin(GameConstants.Goblin, 20, 20, 2);
                    break;
                case 1:
                    unit = new Goblin(GameConstants.Goblin, 30, 30, 3);
                    break;
                default:
                    unit = new Goblin(GameConstants.Goblin, 20, 20, 2);
                    break;
            }
            return unit;
        }

        public override DungeonRoom CreateDungeon()
        {
            DungeonFactory easyDungeonBuilder = new EasyDungeonBuilder();
            return easyDungeonBuilder.BuildDungeon();
        }
    }
}
