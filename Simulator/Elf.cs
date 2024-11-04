using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator;

public class Elf : Creature
{
    private int agility;
    public int Agility 
    {
        get => agility;
        init
        {
            if (value < 0)
            {
                agility = 0;
            }
            else if (value > 10)
            {
                agility = 10;
            }
            else
            {
                agility = value;
            }
        }
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
}
