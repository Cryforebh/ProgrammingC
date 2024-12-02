using GamePrototype.Combat;
using GamePrototype.Dungeon;
using GamePrototype.Items;
using GamePrototype.Units;
using GamePrototype.Utils;

namespace GamePrototype.Game
{
    public sealed class GameLoop
    {
        private Unit _player;
        private DungeonRoom _dungeon;
        private readonly CombatManager _combatManager = new CombatManager();

        public void StartGame() 
        {
            Initialize();
            Console.WriteLine($"Настало время {_player.Name}. Ты входишь в подземелье...");
            StartGameLoop();
        }

        #region Game Loop

        private void Initialize()
        {
            Console.WriteLine("Добро пожаловать, игрок!");
            _dungeon = DungeonBuilder.BuildDungeon();
            Console.Write("Введи свое имя: ");
            _player = UnitFactoryDemo.CreatePlayer(Console.ReadLine());
        }

        private void StartGameLoop()
        {
            var currentRoom = _dungeon;
            
            while (currentRoom.IsFinal == false) 
            {
                StartRoomEncounter(currentRoom, out var success);
                if (!success) 
                {
                    Console.WriteLine("Игра окончена!");
                    return;
                }
                DisplayRouteOptions(currentRoom);
                while (true) 
                {
                    if (Enum.TryParse<Direction>(Console.ReadLine(), out var direction) ) 
                    {
                        currentRoom = currentRoom.Rooms[direction];
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Неверное направление!");
                    }
                }
            }
            Console.WriteLine($"\nТебе удалось дойти до конца, поздравляю!");
            Console.WriteLine($"Твой результат {_player.ToString()}:") ;
        }

        private void StartRoomEncounter(DungeonRoom currentRoom, out bool success)
        {
            success = true;
            if (currentRoom.Loot != null) 
            {
                _player.AddItemToInventory(currentRoom.Loot);
            }
            if (currentRoom.Enemy != null) 
            {
                if (_combatManager.StartCombat(_player, currentRoom.Enemy) == _player)
                {
                    _player.HandleCombatComplete();
                    LootEnemy(currentRoom.Enemy);
                }
                else 
                {
                    success = false;
                }
            }

            void LootEnemy(Unit enemy)
            {
                _player.AddItemsFromUnitToInventory(enemy);
            }
        }

        private void DisplayRouteOptions(DungeonRoom currentRoom)
        {
            DirectionName directionName;
            Console.WriteLine("Какое направление из возможных выберешь?");
            foreach (var room in currentRoom.Rooms)
            {
                Console.Write($"{directionName.Name(room.Key)} - {(int) room.Key}\t");
            }
        }

        
        #endregion
    }
}
