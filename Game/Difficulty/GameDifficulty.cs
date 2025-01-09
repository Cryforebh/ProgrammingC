using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GamePrototype.Game.Difficulty.GameDifficulty;

namespace GamePrototype.Game.Difficulty
{
    public abstract class GameDifficulty
    {
        public string Name { get; set; }

        public GameDifficulty(string name)
        {
            Name = name;
        }

        public abstract Difficulty Create();
    }

    public class EssyDifficultyGame : GameDifficulty
    {
        public EssyDifficultyGame() : base("Низкая сложность") { }

        public override Difficulty Create()
        {
            return new EssyDifficulty(30, 3);
        }
    }

    public class HardDifficultyGame : GameDifficulty
    {
        public HardDifficultyGame() : base("Высокая сложность") { }

        public override Difficulty Create()
        {
            return new HardDifficulty(30, 3);
        }
    }

    public abstract class Difficulty { }

}
