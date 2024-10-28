using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

internal class Creature
{
    private string? name;
    public string? Name { get; set; }

    private int level;
    public int Level { get; set; } = 1;

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public void SayHi() => Console.WriteLine($"Hi, I'm {name}, my level is {level}.");
    public string Info => $"{Name} - {Level}";
}

