
using static Simulator.Directions;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
    }
   
    static void Lab5a()
    {
        try
        {
            Rectangle r1 = new(4, 4, 2, 2);
            Console.WriteLine(r1);

            Rectangle r2 = new(2, 2, 4, 4);
            Console.WriteLine(r2);

            try
            {
                Rectangle r3 = new(3, 8, 3, 9);
                Console.WriteLine(r3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error occured: " + ex.Message);
            }

            Rectangle r4 = new(new Point(2, 2), new Point(6, 8));
            Console.WriteLine(r4);

            Point insidePoint = new(4, 4);
            Point outsidePoint = new(7, 9);

            Console.WriteLine($"Point {insidePoint} {(r4.Contains(insidePoint) ? "is" : "is not")} inside the rectangle {r4}");
            Console.WriteLine($"Point {outsidePoint} {(r4.Contains(outsidePoint) ? "is" : "is not")} inside the rectangle {r4}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occured: " + ex.Message);
        }
    }
}
