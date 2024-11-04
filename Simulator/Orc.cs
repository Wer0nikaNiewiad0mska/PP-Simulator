using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Orc : Creature
{
    private int rage;
    public int Rage 
    {
        get => rage;
        init
        {
            if (value < 0)
            {
                rage = 0;
            }
            else if (value > 10)
            {
                rage = 10;
            }
            else
            {
                rage = value;
            }
        }
    }
    private int count = 0;
    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
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

    public Orc(): base(){}
    public Orc(string name, int level=1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }
    public override void SayHi() => Console.WriteLine(
    $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}."
);
    public override int Power
    {
        get
        {
            return 7 * Level + 3 * Rage;
        }
    }
}
