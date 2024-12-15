using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator.Maps;

/// <summary>
/// Abstract representation of a map.
/// </summary>
public abstract class Map
{
    public readonly int SizeX;
    public readonly int SizeY;
    private readonly Rectangle _limits;
    private readonly Dictionary<Point, List<IMappable>> _fields;

    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "The map is too narrow");

        if (sizeY < 5)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "The map is too short");

        SizeX = sizeX;
        SizeY = sizeY;
        _limits = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        _fields = new Dictionary<Point, List<IMappable>>();

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                _fields[new Point(x, y)] = new List<IMappable>();
            }
        }
    }

    /// <summary>
    /// Add an IMappable object to the map at a specific point.
    /// </summary>
    public void Add(IMappable mappable, Point p)
    {
        if (!_fields.TryGetValue(p, out var list))
            throw new ArgumentException($"Point {p} is out of bounds or not initialized");

        list.Add(mappable);
    }

    /// <summary>
    /// Remove an IMappable object from the map at a specific point.
    /// </summary>
    public void Remove(IMappable mappable, Point p)
    {
        if (!_fields.TryGetValue(p, out var list))
            throw new ArgumentException($"Point {p} is out of bounds or not initialized");

        list.Remove(mappable);
    }

    /// <summary>
    /// Move an IMappable object from one point to another.
    /// </summary>
    public void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }

    /// <summary>
    /// Get all IMappable objects at a specific coordinate (x, y).
    /// </summary>
    public List<IMappable>? At(int x, int y)
    {
        var point = new Point(x, y);
        return At(point);
    }

    /// <summary>
    /// Get all IMappable objects at a specific point.
    /// </summary>
    public List<IMappable>? At(Point p)
    {
        return _fields.TryGetValue(p, out var list) ? list : null;
    }

    /// <summary>
    /// Check if a given point exists on the map.
    /// </summary>
    public virtual bool Exist(Point p) => _limits.Contains(p);

    /// <summary>
    /// Get the next position to the given point in a given direction.
    /// </summary>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Get the next diagonal position to the given point in a direction rotated 45 degrees.
    /// </summary>
    public abstract Point NextDiagonal(Point p, Direction d);
}