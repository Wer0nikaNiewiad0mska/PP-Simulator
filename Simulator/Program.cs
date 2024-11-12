
using Simulator.Maps;
using static Simulator.Directions;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
        Lab5b();
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

    static void Lab5b()
    {
        SmallSquareMap map = new SmallSquareMap(6);

        Point pointInside = new(5, 5);
        Point pointOutside = new(10, 10);
        Point pointOnEdge = new(9, 9);

        Console.WriteLine("\nTesting the Exist method:");
        Console.WriteLine($"Does the point {pointInside} exist on the map? {map.Exist(pointInside)}");
        Console.WriteLine($"Does the point {pointOutside} exist on the map? {map.Exist(pointOutside)}");
        Console.WriteLine($"Does the point {pointOnEdge} exist on the map? {map.Exist(pointOnEdge)}");
        Console.WriteLine();

        Console.WriteLine("Testing the Next method (move right):");
        Point nextPoint = map.Next(pointInside, Directions.Direction.Right);
        Console.WriteLine($"New position after moving right from point {pointInside}: {nextPoint}");

        nextPoint = map.Next(pointOutside, Directions.Direction.Up);
        Console.WriteLine($"New position after moving up from point {pointOutside}: {nextPoint}");
        Console.WriteLine();

        Console.WriteLine("Testing the NextDiagonal method (move up and right):");
        Point nextDiagonalPoint = map.NextDiagonal(pointInside, Directions.Direction.Up);
        Console.WriteLine($"New position after moving diagonally from point {pointInside}: {nextDiagonalPoint}");

        nextDiagonalPoint = map.NextDiagonal(pointOnEdge, Directions.Direction.Up);
        Console.WriteLine($"New position after moving diagonally from point {pointOnEdge}: {nextDiagonalPoint}");
        Console.WriteLine();
    }
}
