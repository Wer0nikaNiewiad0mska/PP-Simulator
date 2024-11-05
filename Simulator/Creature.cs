using static Simulator.Directions;

namespace Simulator;

public abstract class Creature
{
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

    public void Go(Direction direction)
    {
        Console.WriteLine($"{Name} goes {direction.ToString().ToLower()}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string input)
    {
        Direction[] directions = DirectionParser.Parse(input);
        Go(directions);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract void SayHi();
    public abstract string Info { get; }

    public abstract int Power {  get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}

