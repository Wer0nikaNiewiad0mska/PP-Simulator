using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        var directionsKierunki = new List<Direction>();
        foreach (char letter in input)
        {
            switch (char.ToUpper(letter))
            {
                case 'U':
                    directionsKierunki.Add(Direction.Up);
                    break;
                case 'R':
                    directionsKierunki.Add(Direction.Right);
                    break;
                case 'D':
                    directionsKierunki.Add(Direction.Down);
                    break;
                case 'L':
                    directionsKierunki.Add(Direction.Left);
                    break;
                default:
                    break;
            }
        }
        return directionsKierunki;
    }
}