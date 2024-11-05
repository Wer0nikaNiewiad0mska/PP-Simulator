
namespace Simulator
{
    internal class Birds: Animals
    {
        public bool CanFly { get; set; } = true;

        public override string Info
        {
            get
            {
                string flyingability = CanFly ? "fly+" : "fly-";
                return $"{Description} ({flyingability}) <{Size}>";
            }
        }
    }
}
