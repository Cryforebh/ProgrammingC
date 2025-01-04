using GamePrototype.Dungeon;
using GamePrototype.Items.EconomicItems;

namespace GamePrototype.Utils
{
    public static class DungeonBuilder
    {
        public static DungeonRoom BuildDungeon()
        {
            var enter = new DungeonRoom("в пещеру");
            var monsterRoom = new DungeonRoom("комнату с монстром", UnitFactoryDemo.CreateGoblinEnemy(), new HealthPotion());
            var monsterTwoRoom = new DungeonRoom("комнату с Большим монстром", UnitFactoryDemo.CreateGoblinEnemyTwo(), new Gold());
            var emptyRoom = new DungeonRoom("пустую комнату");
            var lootRoomGold = new DungeonRoom("комнату с золотом", new Gold());
            var lootTwoRoomGold = new DungeonRoom("комнату с золотом", new Gold());
            var lootStoneRoom = new DungeonRoom("комнату с точильным камнем", new Grindstone());
            var emptyTwoRoom = new DungeonRoom("пустую комнату");
            var finalRoom = new DungeonRoom("Конец пещеры", new Grindstone());


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
