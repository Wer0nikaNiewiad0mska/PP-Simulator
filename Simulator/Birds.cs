
using Simulator.Maps;
using static Simulator.Directions;

namespace Simulator;

public class Birds : Animals
{
    public override char Symbol => CanFly ? 'B' : 'b';
    public bool CanFly { get; set; } = true;

    public override string Info
    {
        get
        {
            string flyingability = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyingability}) <{Size}>";
        }
    }

    public override void Go(Direction direction)
    {
        if (CanFly)
        {
            var nextPosition = Map.Next(Position, direction);
            Map.Move(this, Position, nextPosition);
            UpdatePosition(nextPosition);

            nextPosition = Map.Next(Position, direction);
            Map.Move(this, Position, nextPosition);
            UpdatePosition(nextPosition);
        }
        else
        {
            var nextPosition = Map.NextDiagonal(Position, direction);
            Map.Move(this, Position, nextPosition);
            UpdatePosition(nextPosition);
        }
    }
}