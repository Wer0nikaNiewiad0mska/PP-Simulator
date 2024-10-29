using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Simulator.Directions;

namespace Simulator;

internal class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            string trimmedName = value.Trim();
            if (trimmedName.Length < 3)
            {
                trimmedName = trimmedName.PadRight(3, '#');
            }
            else if (trimmedName.Length > 25) 
            {
                trimmedName = trimmedName.Substring(0, 25).TrimEnd();
                if (trimmedName.Length < 3) trimmedName = trimmedName.PadRight(3, '#');
            }
            name = char.ToUpper(trimmedName[0]) + trimmedName.Substring(1);
        }
    }

    private int level = 1;
    public int Level 
    { 
        get => level;
        init
        {
            if (level < 1)
            {
                level = 1;
            }
            else if (value > 10)
            {
                level = 10;
            }
        }
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

    public void SayHi() => Console.WriteLine($"Hi, I'm {name}, my level is {level}.");
    public string Info => $"{Name} - {Level}";
}

