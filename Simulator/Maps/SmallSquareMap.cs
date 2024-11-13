using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallSquareMap : Map
{
    public readonly int Size;

    public SmallSquareMap(int size) => Size = size < 5 || size > 20 ? throw new ArgumentOutOfRangeException("Unacceptable size of the map - it must be between 5 and 20.") : size;

    //Metoda Bounds korzysta z metody Contains z klasy Rectangles do sprawdzenia czy punkt mieści się w obrębie prostokąta
    private bool Bounds(Point p)
    {
        Rectangle mapBounds = new(0, 0, Size - 1, Size - 1);
        return mapBounds.Contains(p);
    }
    public override bool Exist(Point p)
    {
        return Bounds(p);
    }


    public override Point Next(Point p, Directions.Direction d)
    {
        Point nextPoint = p.Next(d);
        return Bounds(nextPoint) ? nextPoint : p;
    }

    public override Point NextDiagonal(Point p, Directions.Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return Bounds(nextPoint) ? nextPoint : p;
    }
}

