using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimConsole;

internal class LogVisualizer
{
    private readonly SimulationHistory _log;

    public LogVisualizer(SimulationHistory log)
    {
        _log = log ?? throw new ArgumentNullException(nameof(log));
    }

    public void Draw(int turnIndex)
    {
        if (turnIndex < 0 || turnIndex >= _log.TurnLogs.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(turnIndex), "Turn index out of range.");
        }

        var turnLog = _log.TurnLogs[turnIndex];
        int columns = _log.SizeX;
        int rows = _log.SizeY;

        Console.OutputEncoding = Encoding.UTF8;

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
                var position = new Point(col, row);

                if (turnLog.Symbols.ContainsKey(position))
                {
                    Console.Write(turnLog.Symbols[position]);
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