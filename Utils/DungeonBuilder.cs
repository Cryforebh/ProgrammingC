using GamePrototype.Dungeon;
using GamePrototype.Game.Difficulty.DifficultyLevels;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Utils
{
    public abstract class DungeonFactory
    {
        public DungeonFactory()
        {
        }

        protected DungeonRoom enter = new DungeonRoom("в пещеру");
        protected DungeonRoom monsterRoom;
        protected DungeonRoom monsterTwoRoom;
        protected DungeonRoom emptyRoom = new DungeonRoom("пустую комнату");
        protected DungeonRoom emptyTwoRoom = new DungeonRoom("пустую комнату");
        protected DungeonRoom lootRoomGold;
        protected DungeonRoom lootTwoRoomGold;
        protected DungeonRoom lootStoneRoom = new DungeonRoom("комнату с точильным камнем", new Grindstone());
        protected DungeonRoom finalRoom = new DungeonRoom("Конец пещеры", new Grindstone());

        public abstract DungeonRoom BuildDungeon();
        public void DungeonGeneration()
        {
            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Forward, lootStoneRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoomGold);
            monsterRoom.TrySetDirection(Direction.Left, emptyRoom);
            monsterRoom.TrySetDirection(Direction.Right, monsterRoom);

            emptyRoom.TrySetDirection(Direction.Left, lootStoneRoom);
            emptyRoom.TrySetDirection(Direction.Forward, monsterTwoRoom);

            lootRoomGold.TrySetDirection(Direction.Forward, monsterTwoRoom);
            lootRoomGold.TrySetDirection(Direction.Right, lootStoneRoom);
            lootRoomGold.TrySetDirection(Direction.Left, emptyTwoRoom);

            lootStoneRoom.TrySetDirection(Direction.Right, emptyTwoRoom);

            emptyTwoRoom.TrySetDirection(Direction.Left, monsterTwoRoom);

            monsterTwoRoom.TrySetDirection(Direction.Forward, lootTwoRoomGold);

            lootTwoRoomGold.TrySetDirection(Direction.Forward, finalRoom);
        }
    }

    public class EasyDungeonBuilder : DungeonFactory
    {
        public override DungeonRoom BuildDungeon()
        {
            monsterRoom = new DungeonRoom("комнату с монстром", EasyLvlFactories.CreateGoblinEnemy(0), new HealthPotion());
            monsterTwoRoom = new DungeonRoom("комнату с Большим монстром", EasyLvlFactories.CreateGoblinEnemy(1), new Gold(24));
            lootRoomGold = new DungeonRoom("комнату с золотом", new Gold(66));
            lootTwoRoomGold = new DungeonRoom("комнату с золотом", new Gold(120));

            DungeonGeneration();
            return enter;
        }
    }

    public class HardDungeonBuilder : DungeonFactory
    {
        public override DungeonRoom BuildDungeon()
        {
            monsterRoom = new DungeonRoom("комнату с монстром", HardLvlFactories.CreateGoblinEnemy(0), new HealthPotion());
            monsterTwoRoom = new DungeonRoom("комнату с Большим монстром", HardLvlFactories.CreateGoblinEnemy(1), new Gold(8));
            lootRoomGold = new DungeonRoom("комнату с золотом", new Gold(22));
            lootTwoRoomGold = new DungeonRoom("комнату с золотом", new Gold(40));

            DungeonGeneration();
            return enter;
        }
    }

    public class DefaultDungeonBuilder : DungeonFactory
    {
        public override DungeonRoom BuildDungeon()
        {
            monsterRoom = new DungeonRoom("комнату с монстром", DefaultLvlFactories.CreateGoblinEnemy(0), new HealthPotion());
            monsterTwoRoom = new DungeonRoom("комнату с Большим монстром", DefaultLvlFactories.CreateGoblinEnemy(1), new Gold(16));
            lootRoomGold = new DungeonRoom("комнату с золотом", new Gold(44));
            lootTwoRoomGold = new DungeonRoom("комнату с золотом", new Gold(80));

            DungeonGeneration();
            return enter;
        }
    }
}
