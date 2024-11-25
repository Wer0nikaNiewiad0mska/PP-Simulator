﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields;

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
        _fields[p.X, p.Y]?.Add(creature);
        creature.InitMapAndPosition(this, p);
    }

    public override void Remove(Creature creature, Point p)
    {
        _fields[p.X, p.Y]?.Remove(creature);
    }

    public override void Move(Creature creature, Point from, Point to)
    {
        _fields[from.X, from.Y]?.Remove(creature);
        _fields[to.X, to.Y]?.Add(creature);
    }

    public override List<Creature>? At(int x, int y)
    {
        return _fields[x, y];
    }

    public override List<Creature>? At(Point p)
    {
        return _fields[p.X, p.Y];
    }
}