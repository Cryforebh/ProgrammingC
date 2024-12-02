using GamePrototype.Items;
using GamePrototype.Units;

namespace GamePrototype.Combat
{
    public sealed class CombatManager
    {
        RockPaperScissorsName rockPaperScissorsName;

        private readonly Random _random = new();
        
        public Unit StartCombat(Unit player, Unit enemy) => PlayCombatRoutine(player, enemy);

        private Unit PlayCombatRoutine(Unit player, Unit enemy)
        {
            Console.WriteLine(GetCombatString());
            while (player.Health > 0 && enemy.Health > 0) 
            {
                if (Enum.TryParse<RockPaperScissors>(Console.ReadLine(), out var rockPaperScissors)) 
                {
                    HandleCombatInput(player, enemy, rockPaperScissors);
                }
                else
                {
                    Console.WriteLine(GetCombatString());
                }
            }
            if (player.Health > 0 && enemy.Health == 0) 
            {
                return player;
            }
            else if (player.Health == 0 && enemy.Health > 0) 
            {
                return enemy;
            }

            return null;
        }

        private string GetCombatString()
        {
            return
            $"Выбери: {rockPaperScissorsName.Name(RockPaperScissors.Rock)} = {(int)RockPaperScissors.Rock}" +
            $", или {rockPaperScissorsName.Name(RockPaperScissors.Paper)} = {(int)RockPaperScissors.Paper}" +
            $", или {rockPaperScissorsName.Name(RockPaperScissors.Scissors)} = {(int)RockPaperScissors.Scissors}";
        }

        private void HandleCombatInput(Unit player, Unit enemy, RockPaperScissors rockPaperScissors)
        {
            var enemyInput = (RockPaperScissors) _random.Next(1, 3);
            Console.WriteLine($"Результат игрока = {rockPaperScissorsName.Name(rockPaperScissors)}, а у противника = {rockPaperScissorsName.Name(enemyInput)}");
            switch (rockPaperScissors) 
            {
                // player hit
                case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Scissors:
                    ApplyDamage(player, enemy);
                    break;
                case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Paper:
                    ApplyDamage(player, enemy);
                    break;
                case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Rock:
                    ApplyDamage(player, enemy);
                    break;
                // enemy hit
                case RockPaperScissors.Scissors when enemyInput == RockPaperScissors.Rock:
                    ApplyDamage(enemy, player);
                    break;
                case RockPaperScissors.Paper when enemyInput == RockPaperScissors.Scissors:
                    ApplyDamage(enemy, player);
                    break;
                case RockPaperScissors.Rock when enemyInput == RockPaperScissors.Paper:
                    ApplyDamage(enemy, player);
                    break;
                default:
                    Console.WriteLine("Бойцы попытались нанести удар, но промахнулись :(");
                    break;
            }
        }

        private void ApplyDamage(Unit attacker, Unit defender)
        {
            defender.ApplyDamage(attacker.GetUnitDamage());
            Console.WriteLine($"{attacker.Name} попадает! {defender.Name} получает урон и его здоровье теперь {defender.Health}/{defender.MaxHealth}");
            if (defender.Health == 0) 
            {
                Console.WriteLine($"{defender.Name} мертв!");
            }
        }
    }
}
