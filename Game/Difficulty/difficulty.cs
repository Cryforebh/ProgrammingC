using GamePrototype.Items.EconomicItems;
using GamePrototype.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePrototype.Game.Difficulty
{

    //interface Idifficulty
    //{
    //    protected uint PlayerHealth { get; }
    //    protected uint PlayerMaxHealth { get; }
    //    protected uint PlayerBaseDamage { get; }

    //    protected uint NPCHealth { get; }
    //    protected uint NPCMaxHealth { get; }
    //    protected uint NPCHealthDamage { get; }
    //}

    //public class DefaultDifficylty : Idifficulty
    //{
    //    public uint PlayerHealth => 25;
    //    public uint PlayerMaxHealth => 30;
    //    public uint PlayerBaseDamage => 3;

    //    public uint NPCHealth => 20;
    //    public uint NPCMaxHealth => 25;
    //    public uint NPCHealthDamage => 4;
    //}
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
