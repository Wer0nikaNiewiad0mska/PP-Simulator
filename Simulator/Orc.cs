
namespace Simulator;

public class Orc : Creature
{
    public override char Symbol { get; } = 'O';
    private int rage;
    public int Rage
    {
        get => rage;
        init => rage = Validator.Limiter(value, 0, 10);
    }
    private int count = 0;
    public void Hunt()
    {
        count++;
        if (count % 2 == 0)
        {
            if (!(rage == 10))
            {
                rage++;
            }
            else
            {
                rage = 10;
            }
        }
    }

    public Orc() : base() { }
    public Orc(string name, int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public override string Greeting() { return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."; }
    public override int Power
    {
        get
        {
            return 7 * Level + 3 * Rage;
        }
    }
    public override string Info
    {
        get { return $"{Name} [{Level}] [{Rage}]"; }
    }
}