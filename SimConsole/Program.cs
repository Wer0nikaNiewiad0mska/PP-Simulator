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
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Króliki", Size = 11 }, new Birds() { Description = "Orły", Size = 3 }, new Birds() { Description = "Strusie", CanFly = false }];
        List<Point> points = [new(2, 2), new(3, 1), new(5, 2), new(6, 0), new(6, 3)];
        string moves = "dlrludlldrluuduldurr";

        Simulation simulation = new(map, creatures, points, moves);
        SimulationHistory history = simulation.History;
        MapVisualizer mapVisualizer = new(simulation.Map);

        var turn = 1;
        mapVisualizer.Draw();
        history.GetSnapshot(turn).DisplaySnapshot();



        while (!simulation.Finished)
        {
            Console.ReadKey();

            Console.WriteLine($"Tura {turn}");
            Console.Write($"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}\n");



            Console.WriteLine();
            simulation.Turn();
            history.AddSnapshot(simulation);
            mapVisualizer.Draw();
            history.GetSnapshot(turn).DisplaySnapshot();
            turn++;
            if (turn > 20) break;
        }
        for (int i = 5; i <= 20; i += 5)
        {
            Console.WriteLine($"--- Turn {i} ---");
            history.GetSnapshot(i).DisplaySnapshot();
            Console.WriteLine();
        }
    }
}