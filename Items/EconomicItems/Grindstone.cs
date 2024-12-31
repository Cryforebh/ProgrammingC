namespace GamePrototype.Items.EconomicItems
{
    public sealed class Grindstone : EconomicItem
    {
        public uint GrindstoneRestore => 7;
        public override bool Stackable => false;

        public Grindstone(string name) : base(name)
        {
        }    
    }
}
