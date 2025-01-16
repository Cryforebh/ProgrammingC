using GamePrototype.Dungeon;
using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Game.Difficulty
{
    public class InitializeDifficulty
    {
        public Difficylty _difficylty;
        public DungeonAbs dungeonAbs;
        private uint _volue { get; set; }
        public void Initialize()
        {
            Console.Write("Выбери сложность (0 - Легко, 1 - Тяжело):");
            _volue = uint.Parse(Console.ReadLine());
            if (_volue == 0)
            {
                _difficylty = new EasyDifficylty();
                dungeonAbs = _difficylty.Create();
            }
            else
            {
                _difficylty = new HardDifficylty();
                dungeonAbs = _difficylty.Create();
            }
        }
        
        public DungeonRoom BuildDungeon() => dungeonAbs.BuildDungeon();
        public Difficylty Difficylty() => _difficylty;
    }
}
