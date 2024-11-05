
namespace Simulator;

public class Elf : Creature
{
    private int agility;
    public int Agility 
    {
        get => agility;
        init => agility = Validator.Limiter(value, 0, 10);
    }
    private int count = 0;
    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        count++;
        if (count%3==0)
        {
            if (!(agility==10))
            {
                agility++;
            }
            else 
            {
                agility = 10;
            }
        }
    }

    public Elf(): base(){}
    public Elf(string name, int level =1, int agility = 1 ): base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}."
);
    public override int Power
    {
        get
        {
            return 8 * Level + 2 * Agility;
        }
    }
    public override string Info
    {
        get { return $"{Name} [{Level}] [{Agility}]"; }
    }
}
