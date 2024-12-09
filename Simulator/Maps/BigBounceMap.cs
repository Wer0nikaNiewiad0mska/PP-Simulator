using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Directions.Direction d)
    {
        int nextX = p.X;
        int nextY = p.Y;

        switch (d)
        {
            case Directions.Direction.Up:
                nextY = (p.Y == SizeY - 1) ? p.Y - 1 : p.Y + 1;
                break;
            case Directions.Direction.Down:
                nextY = (p.Y == 0) ? p.Y + 1 : p.Y - 1;
                break;
            case Directions.Direction.Left:
                nextX = (p.X == 0) ? p.X + 1 : p.X - 1;
                break;
            case Directions.Direction.Right:
                nextX = (p.X == SizeX - 1) ? p.X - 1 : p.X + 1;
                break;
        }

        return new Point(nextX, nextY);
    }

    public override Point NextDiagonal(Point p, Directions.Direction d)
    {
        int nextX = p.X;
        int nextY = p.Y;

        switch (d)
        {
            case Directions.Direction.Up:
                nextY = (p.Y == SizeY - 1) ? p.Y - 1 : p.Y + 1;
                nextX = (p.X == SizeX - 1) ? p.X - 1 : p.X + 1;
                break;

            case Directions.Direction.Down:
                nextY = (p.Y == 0) ? p.Y + 1 : p.Y - 1;
                nextX = (p.X == 0) ? p.X + 1 : p.X - 1;
                break;

            case Directions.Direction.Left:
                nextX = (p.X == 0) ? p.X + 1 : p.X - 1;
                nextY = (p.Y == SizeY - 1) ? p.Y - 1 : p.Y + 1;
                break;

            case Directions.Direction.Right:
                nextX = (p.X == SizeX - 1) ? p.X - 1 : p.X + 1;
                nextY = (p.Y == 0) ? p.Y + 1 : p.Y - 1;
                break;
        }

        return new Point(nextX, nextY);
    }
}
