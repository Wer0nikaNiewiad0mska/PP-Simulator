using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<IMappable>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeX > 20) throw new ArgumentOutOfRangeException(nameof(SizeX), "Map is too wide");
        if (SizeY > 20) throw new ArgumentOutOfRangeException(nameof(SizeY), "Map is too long");
        _fields = new List<IMappable>?[SizeX, SizeY];

        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                _fields[i, j] = new List<IMappable>();
            }
        }
    }

    public override void Add(IMappable mappable, Point p)
    {
        _fields[p.X, p.Y]?.Add(mappable);
    }

    public override void Remove(IMappable mappable, Point p)
    {
        _fields[p.X, p.Y]?.Remove(mappable);
    }

    public override void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    public override List<IMappable>? At(int x, int y)
    {
        if (x < 0 || x >= SizeX || y < 0 || y >= SizeY)
            return null;

        return _fields[x, y];
    }

    public override List<IMappable>? At(Point p)
    {
        return _fields[p.X, p.Y];
    }

}