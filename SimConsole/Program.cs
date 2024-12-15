using Simulator.Maps;
using Simulator;
using SimConsole;


namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Console.WriteLine("Starting positions");

        BigBounceMap map = new(8, 6);
        List<IMappable> creatures = new()
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals() { Description = "Króliki", Size = 11 },
            new Birds() { Description = "Orły", Size = 3 },
            new Birds() { Description = "Strusie", CanFly = false }
        };
        List<Point> points = new()
        {
            new(2, 2), new(3, 1), new(5, 2), new(6, 0), new(6, 3)
        };
        string moves = "dlrludlldrluuduldurr";

        Simulation simulation = new(map, creatures, points, moves);
        SimulationHistory history = simulation.History;

        LogVisualizer logVisualizer = new(history);

        var turn = 1;

        Console.WriteLine("\n--- Initial State ---");
        logVisualizer.Draw(0); 
        DisplayTurnLog(history.TurnLogs.FirstOrDefault());

        while (!simulation.Finished)
        {
            Console.ReadKey();

            Console.WriteLine($"--- Turn {turn} ---");
            Console.Write($"{simulation.CurrentMappable.Info} at {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}\n");

            simulation.Turn();
            logVisualizer.Draw(turn);
            DisplayTurnLog(history.TurnLogs.ElementAtOrDefault(turn));
            turn++;

            if (turn > 20) break;
        }

        Console.WriteLine("\n--- Simulation Summary ---");
        for (int i = 5; i <= 20; i += 5)
        {
            Console.WriteLine($"--- Turn {i} ---");
            DisplayTurnLog(history.TurnLogs.ElementAtOrDefault(i - 1));
            Console.WriteLine();
        }
    }

    private static void DisplayTurnLog(SimulationTurnLog? turnLog)
    {
        if (turnLog == null)
        {
            Console.WriteLine("No data available for this turn.");
            return;
        }

        Console.WriteLine($"Mappable: {turnLog.Mappable}");
        Console.WriteLine($"Move: {turnLog.Move}");

        Console.WriteLine("Map State:");
        foreach (var entry in turnLog.Symbols)
        {
            Console.WriteLine($"Position: {entry.Key} - Symbol: {entry.Value}");
        }
    }
}