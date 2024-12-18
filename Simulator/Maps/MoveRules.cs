using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator.Maps;

internal static class MoveRules
{
    public static Point WallNext(Map m,Point p, Direction d)
    {
        var moved = p.Next(d);
        return m.Exist(moved) ? moved : p;
    }

    public static Point WallNextDiagonal(Map m,Point p, Direction d)
    {
        var moved = p.NextDiagonal(d);
        return !m.Exist(moved) ? p : moved;
    }

    public static Point BounceNext(Map m, Point p, Directions.Direction d)
    {
        int nextX = p.X;
        int nextY = p.Y;

        switch (d)
        {
            case Directions.Direction.Up:
                nextY = (p.Y == m.SizeY - 1) ? p.Y - 1 : p.Y + 1;
                break;
            case Directions.Direction.Down:
                nextY = (p.Y == 0) ? p.Y + 1 : p.Y - 1;
                break;
            case Directions.Direction.Left:
                nextX = (p.X == 0) ? p.X + 1 : p.X - 1;
                break;
            case Directions.Direction.Right:
                nextX = (p.X == m.SizeX - 1) ? p.X - 1 : p.X + 1;
                break;
        }

        return new Point(nextX, nextY);
    }

    public static Point BounceNextDiagonal(Map m, Point p, Directions.Direction d)
    {
        int nextX = p.X;
        int nextY = p.Y;

        switch (d)
        {
            case Directions.Direction.Up:
                nextY = (p.Y == m.SizeY - 1) ? p.Y - 1 : p.Y + 1;
                nextX = (p.X == m.SizeX - 1) ? p.X - 1 : p.X + 1;
                break;

            case Directions.Direction.Down:
                nextY = (p.Y == 0) ? p.Y + 1 : p.Y - 1;
                nextX = (p.X == 0) ? p.X + 1 : p.X - 1;
                break;

            case Directions.Direction.Left:
                nextX = (p.X == 0) ? p.X + 1 : p.X - 1;
                nextY = (p.Y == m.SizeY - 1) ? p.Y - 1 : p.Y + 1;
                break;

            case Directions.Direction.Right:
                nextX = (p.X == m.SizeX - 1) ? p.X - 1 : p.X + 1;
                nextY = (p.Y == 0) ? p.Y + 1 : p.Y - 1;
                break;
        }

        return new Point(nextX, nextY);
    }

    public static Point TorusNext(Map m, Point p, Directions.Direction d)
    {
        int newX = (p.X + (d == Directions.Direction.Right ? 1 : d == Directions.Direction.Left ? -1 : 0) + m.SizeX) % m.SizeX;
        int newY = (p.Y + (d == Directions.Direction.Up ? 1 : d == Directions.Direction.Down ? -1 : 0) + m.SizeY) % m.SizeY;
        return new Point(newX, newY);
    }

    public static Point TorusNextDiagonal(Map m, Point p, Directions.Direction d)
    {
        int newX = p.X;
        int newY = p.Y;

        if (d == Direction.Up)
        {
            newX = (p.X + 1 + m.SizeX) % m.SizeX;
            newY = (p.Y + 1 + m.SizeY) % m.SizeY;
        }
        else if (d == Direction.Down)
        {
            newX = (p.X - 1 + m.SizeX) % m.SizeX;
            newY = (p.Y - 1 + m.SizeY) % m.SizeY;
        }
        else if (d == Direction.Left)
        {
            newX = (p.X - 1 + m.SizeX) % m.SizeX;
            newY = (p.Y + 1 + m.SizeY) % m.SizeY;
        }
        else if (d == Direction.Right)
        {
            newX = (p.X + 1 + m.SizeX) % m.SizeX;
            newY = (p.Y - 1 + m.SizeY) % m.SizeY;
        }

        return new Point(newX, newY);
    }
}
