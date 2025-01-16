using GamePrototype.Dungeon;
using GamePrototype.Game.Difficulty;
using GamePrototype.Items.EconomicItems;
using GamePrototype.Units;

namespace GamePrototype.Utils
{
    public abstract class DungeonAbs
    {
        public DungeonAbs() 
        { 
        }

        protected DungeonRoom enter = new DungeonRoom("в пещеру");
        protected DungeonRoom monsterRoom = new DungeonRoom("комнату с монстром", UnitFactoryDemo.CreateGoblinEnemy(), new HealthPotion());
        protected DungeonRoom monsterTwoRoom = new DungeonRoom("комнату с Большим монстром", UnitFactoryDemo.CreateGoblinEnemyTwo(), new Gold());
        protected DungeonRoom emptyRoom = new DungeonRoom("пустую комнату");
        protected DungeonRoom lootRoomGold = new DungeonRoom("комнату с золотом", new Gold());
        protected DungeonRoom lootTwoRoomGold = new DungeonRoom("комнату с золотом", new Gold());
        protected DungeonRoom lootStoneRoom = new DungeonRoom("комнату с точильным камнем", new Grindstone());
        protected DungeonRoom emptyTwoRoom = new DungeonRoom("пустую комнату");
        protected DungeonRoom finalRoom = new DungeonRoom("Конец пещеры", new Grindstone());

        public abstract DungeonRoom BuildDungeon();

        //public Unit CreateEnemyDifficylty(Difficylty difficylty)
        //{
        //    Unit unit = UnitFactoryDemo.CreateGoblinEnemy();
        //    unit.DifficyltyNPCAdd(difficylty);
        //    return unit;
        //}
    }

    public class EasyDungeonBuilder : DungeonAbs
    {
        public override DungeonRoom BuildDungeon()
        {


            enter.TrySetDirection(Direction.Right, monsterRoom);
            enter.TrySetDirection(Direction.Forward, lootStoneRoom);
            enter.TrySetDirection(Direction.Left, emptyRoom);

            monsterRoom.TrySetDirection(Direction.Forward, lootRoomGold);
            monsterRoom.TrySetDirection(Direction.Left, lootTwoRoomGold);
            monsterRoom.TrySetDirection(Direction.Right, lootStoneRoom);

            emptyRoom.TrySetDirection(Direction.Left, monsterRoom);

            lootRoomGold.TrySetDirection(Direction.Right, lootStoneRoom);
            lootRoomGold.TrySetDirection(Direction.Left, lootTwoRoomGold);
            lootRoomGold.TrySetDirection(Direction.Forward, finalRoom);

            lootStoneRoom.TrySetDirection(Direction.Right, lootTwoRoomGold);

            lootTwoRoomGold.TrySetDirection(Direction.Forward, finalRoom);

            return enter;
        }
    }

    public class HardDungeonBuilder : DungeonAbs
    {
        public override DungeonRoom BuildDungeon()
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

            return enter;
        }
    }
}
