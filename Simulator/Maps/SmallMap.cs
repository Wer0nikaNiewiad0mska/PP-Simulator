using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private List<Creature>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeX > 20) throw new ArgumentOutOfRangeException(nameof(SizeX), "Map is too wide");
        if (SizeY > 20) throw new ArgumentOutOfRangeException(nameof(SizeY), "Map is too long");
        _fields = new List<Creature>?[SizeX, SizeY];

        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                _fields[i, j] = new List<Creature>();
            }
        }
    }

    public override void Add(Creature creature, Point p)
    {
        if (!Exist(p)) throw new ArgumentOutOfRangeException(nameof(p), "Point is out of map bounds.");
        if (_fields[p.X, p.Y] == null)
        {
            _fields[p.X, p.Y] = new List<Creature>();
        }
        _fields[p.X, p.Y]?.Add(creature);
        creature.InitMapAndPosition(this, p);
    }

    public override void Remove(Creature creature, Point p)
    {
        if (!Exist(p)) throw new ArgumentOutOfRangeException(nameof(p), "Point is out of map bounds.");
        _fields[p.X, p.Y]?.Remove(creature);
        if (_fields[p.X, p.Y]?.Count == 0)
        {
            _fields[p.X, p.Y] = null;
        }
    }

    public override void Move(Creature creature, Point from, Point to)
    {
        if (!Exist(from) || !Exist(to)) throw new ArgumentOutOfRangeException("Points are out of map bounds.");
        Remove(creature, from);
        Add(creature, to);
    }

    public override List<Creature>? At(int x, int y)
    {
        if (x < 0 || x >= SizeX || y < 0 || y >= SizeY)
        {
            return null;
        }
        return _fields[x, y];
    }

    public override List<Creature>? At(Point p)
    {
        return At(p.X, p.Y);
    }
}