using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    private readonly Rectangle _limits;
    public int Size { get; }

    public SmallTorusMap(int size)
    {
        if (size < 5 || size > 20) throw new ArgumentOutOfRangeException("Given wrong map parameters. Map size must be between 5 and 20.");
        Size = size;
        _limits = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    public override bool Exist(Point p) => _limits.Contains(p);

    public override Point Next(Point p, Directions.Direction d)
    {
        int newX = (p.X + (d == Directions.Direction.Right ? 1 : d == Directions.Direction.Left ? -1 : 0) + Size) % Size;
        int newY = (p.Y + (d == Directions.Direction.Up ? 1 : d == Directions.Direction.Down ? -1 : 0) + Size) % Size;
        return new Point(newX, newY);
    }


    public override Point NextDiagonal(Point p, Directions.Direction d)
    {
        int newX = p.X;
        int newY = p.Y;

        if (d == Direction.Up)
        {
            newX = (p.X + 1 + Size) % Size;
            newY = (p.Y + 1 + Size) % Size; 
        }
        else if (d == Direction.Down)
        {
            newX = (p.X - 1 + Size) % Size; 
            newY = (p.Y - 1 + Size) % Size; 
        }
        else if (d == Direction.Left)
        {
            newX = (p.X - 1 + Size) % Size; 
            newY = (p.Y + 1 + Size) % Size; 
        }
        else if (d == Direction.Right)
        {
            newX = (p.X + 1 + Size) % Size; 
            newY = (p.Y - 1 + Size) % Size; 
        }

        return new Point(newX, newY);
    }
}
