using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Game.Difficulty
{
    public abstract class Difficylty
    {
        protected string _name = "Стандартная сложность";
        protected uint _value = 2;

        public uint difficyltyValue => _value;

        public void Info()
        {
            Console.WriteLine(_name);
        }

        public abstract DungeonAbs Create();
    }
    public class DefaultDifficylty : Difficylty
    {
        public DefaultDifficylty()
        {

        }

        public override DungeonAbs Create()
        {
            return new EasyDungeonBuilder();
        }
    }

    public class EasyDifficylty : Difficylty
    {
        public EasyDifficylty()
        {
            _name = "Легкая сложность";
            _value = 1;
        }

        public override DungeonAbs Create()
        {
            return new EasyDungeonBuilder();
        }
    }

    public class HardDifficylty : Difficylty
    {
        public HardDifficylty()
        {
            _name = "Тяжелая сложность";
            _value = 3;
        }

        public override DungeonAbs Create()
        {
            return new HardDungeonBuilder();
        }
    }
}
