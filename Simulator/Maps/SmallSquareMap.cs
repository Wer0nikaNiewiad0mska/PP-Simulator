using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    private readonly Rectangle _limits;
    public int Size { get; }
    public SmallSquareMap(int size)
    {
        if (size < 5 || size > 20) throw new ArgumentOutOfRangeException("Given wrong map parameters. Map size must be between 5 and 20.");
        Size = size;
        _limits = new Rectangle(0, 0, Size - 1, Size - 1);
    }
    public override bool Exist(Point p) => _limits.Contains(p);
    public override Point Next(Point p, Direction d)
    {
        var moved = p.Next(d);
        return !Exist(moved) ? p : moved;
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        return !Exist(moved) ? p : moved;
    }
}

