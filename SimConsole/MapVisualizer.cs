using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map;
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        int columns = _map.SizeX;
        int rows = _map.SizeY;

        // Góra planszy
        Console.Write($"{Box.TopLeft}");
        for (int i = 0; i < columns - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        // Wiersze mapy
        for (int row = rows - 1; row >= 0; row--)
        {
            Console.Write(Box.Vertical);
            for (int col = 0; col < columns; col++)
            {
                var creatures = _map.At(col, row);


                if (creatures?.Count > 1)
                {
                    Console.Write("X");
                }
                else if (creatures?.Count == 1)
                {
                    char symbol = creatures[0] is Elf ? 'E' : 'O';
                    Console.Write(symbol);
                }
                else
                {
                    Console.Write(" ");
                }

                Console.Write(Box.Vertical);
            }
            Console.WriteLine();

            if (row > 0)
            {
                Console.Write(Box.MidLeft);
                for (int i = 0; i < columns - 1; i++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }

        // Dół planszy
        Console.Write(Box.BottomLeft);
        for (int i = 0; i < columns - 1; i++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");
    }
}
