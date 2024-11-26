using Simulator.Maps;
using static Simulator.Directions;

namespace Simulator;

public abstract class Creature
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    public void InitMapAndPosition(Map map, Point position)
    {
        Map = map;
        Position = position;
        map.Add(this, position);
    }

    private string name = "Unknown";
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
    }

    private int level = 1;
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
    }

    public void Upgrade()
    {
        if (level < 10)
        {
            level++;
        }
    }

    public string Go(Direction direction)
    {
        Map?.Move(this, Position, Map.Next(Position, direction));
        Position = Map.Next(Position, direction);

        return $"{direction.ToString().ToLower()}";
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Greeting();
    public abstract string Info { get; }

    public abstract int Power { get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}