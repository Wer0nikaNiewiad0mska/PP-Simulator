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

        SmallTorusMap map = new(8, 6);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor"), new Animals() { Description = "Króliki", Size = 11 }, new Birds() { Description = "Orły", Size = 3 }, new Birds() { Description = "Strusie", CanFly = false }];
        List<Point> points = [new(2, 2), new(3, 1), new(5, 2), new(6, 0), new(6, 3)];
        string moves = "dlrludlldrluudd";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        var turn = 1;
        mapVisualizer.Draw();


        while (!simulation.Finished)
        {
            Console.ReadKey();

            Console.WriteLine($"Tura {turn}");
            Console.Write($"{simulation.CurrentMappable.Info} {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}\n");



            Console.WriteLine();
            simulation.Turn();
            mapVisualizer.Draw();
            turn++;

        }
    }
}