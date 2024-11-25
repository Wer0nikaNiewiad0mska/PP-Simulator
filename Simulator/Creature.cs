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

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public List<string> Go(List<Direction> directions)
    {
        List<string> result = new List<string>(directions.Count);
        for (int i=0; i < directions.Count; i++)
        {
            result[i] = Go(directions[i]);
        }
        return result;
    }

    public List<string> Go(string input)
    {
        List<Direction> directions = DirectionParser.Parse(input);
        return  Go(input);
    }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public abstract string Greeting();
    public abstract string Info { get; }

    public abstract int Power {  get; }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }

}

