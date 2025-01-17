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
        private Difficylty _difficylty;
        private DungeonAbs _dungeonAbs;
        private uint _volue { get; set; }
        public void Initialize()
        {
            Console.Write("Выбери сложность (0 - Легко, 1 - Тяжело):");
            _volue = uint.Parse(Console.ReadLine());
            if (_volue == 0)
            {
                _difficylty = new EasyDifficylty();
                _dungeonAbs = _difficylty.Create();
            }
            else
            {
                _difficylty = new HardDifficylty();
                _dungeonAbs = _difficylty.Create();
            }
        }
        
        public DungeonRoom BuildDungeon() => _dungeonAbs.BuildDungeon();
        public Difficylty Difficylty() => _difficylty;
    }
}
