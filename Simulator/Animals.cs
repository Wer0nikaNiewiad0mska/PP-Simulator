using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Simulator.Directions;

namespace Simulator;

public class Animals : IMappable
{
    public virtual char Symbol { get; } = 'A';
    private string description = "Unknown";
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public required string Description
    {
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
        map.Add(this, position);
    }
    public void UpdatePosition(Point newPosition)
    {
        Position = newPosition;
    }

    public virtual void Go(Direction direction)
    {
        Point newPosition = Map?.Next(Position, direction) ?? Position;
        Map?.Move(this, Position, newPosition);
        Position = newPosition;
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
    public Point CurrentPosition()
    {
        return Position;
    }
}