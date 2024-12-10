using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class BigMap : Map
{
    Dictionary<Point, List<IMappable>> _fields;

    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeX > 1000) throw new ArgumentOutOfRangeException(nameof(SizeX), "Map is too wide");
        if (SizeY > 1000) throw new ArgumentOutOfRangeException(nameof(SizeY), "Map is too long");
        _fields = new Dictionary<Point, List<IMappable>>();

        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                var point = new Point(i, j);
                _fields[point] = new List<IMappable>();
            }
        }
    }

    public override void Add(IMappable mappable, Point p)
    {
        if (_fields.TryGetValue(p, out var list))
        {
            list.Add(mappable);
        }
        else
        {
            throw new ArgumentException($"Point {p} is out of bounds or not initialized");
        }
    }

    public override void Remove(IMappable mappable, Point p)
    {
        if (_fields.TryGetValue(p, out var list))
        {
            list.Remove(mappable);
        }
        else
        {
            throw new ArgumentException($"Point {p} is out of bounds or not initialized");
        }
    }

    public override void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public override List<IMappable>? At(int x, int y)
    {
        var point = new Point(x, y);
        return At(point);
    }

    public override List<IMappable>? At(Point p)
    {
        if (_fields.TryGetValue(p, out var list))
        {
            return list;
        }
        return null;
    }
    public abstract override Point Next(Point p, Directions.Direction d);
    public abstract override Point NextDiagonal(Point p, Directions.Direction d);
}