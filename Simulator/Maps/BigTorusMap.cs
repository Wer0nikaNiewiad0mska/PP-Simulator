using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Directions.Direction d)
    {
        int newX = (p.X + (d == Directions.Direction.Right ? 1 : d == Directions.Direction.Left ? -1 : 0) + SizeX) % SizeX;
        int newY = (p.Y + (d == Directions.Direction.Up ? 1 : d == Directions.Direction.Down ? -1 : 0) + SizeY) % SizeY;
        return new Point(newX, newY);
    }


    public override Point NextDiagonal(Point p, Directions.Direction d)
    {
        int newX = p.X;
        int newY = p.Y;

        if (d == Direction.Up)
        {
            newX = (p.X + 1 + SizeX) % SizeX;
            newY = (p.Y + 1 + SizeY) % SizeY;
        }
        else if (d == Direction.Down)
        {
            newX = (p.X - 1 + SizeX) % SizeX;
            newY = (p.Y - 1 + SizeY) % SizeY;
        }
        else if (d == Direction.Left)
        {
            newX = (p.X - 1 + SizeX) % SizeX;
            newY = (p.Y + 1 + SizeY) % SizeY;
        }
        else if (d == Direction.Right)
        {
            newX = (p.X + 1 + SizeX) % SizeX;
            newY = (p.Y - 1 + SizeY) % SizeY;
        }

        return new Point(newX, newY);
    }
}