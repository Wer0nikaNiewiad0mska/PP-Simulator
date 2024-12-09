﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public abstract void Add(IMappable mappable, Point p);
    public abstract void Remove(IMappable mappable, Point p);
    public abstract void Move(IMappable mappable, Point from, Point to);

    public abstract List<IMappable>? At(int x, int y);
    public abstract List<IMappable>? At(Point p);

    public readonly int SizeX;
    public readonly int SizeY;

    private readonly Rectangle _limits;
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(SizeX), "Too narrow");
        }

        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(SizeY), "Too short");
        }

        SizeX = sizeX;
        SizeY = sizeY;
        _limits = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
    }
    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _limits.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}