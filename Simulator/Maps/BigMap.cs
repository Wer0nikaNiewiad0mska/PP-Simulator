using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class BigMap : Map
{
    Dictionary<Point, List<IMappable>> _fields;

    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (SizeX > 1000) throw new ArgumentOutOfRangeException(nameof(SizeX), "Map is too wide");
        if (SizeY > 1000) throw new ArgumentOutOfRangeException(nameof(SizeY), "Map is too long");
        _fields = new Dictionary<Point, List<IMappable>>();

        for (int i = 0; i < SizeX; i++)
        {
            for (int j = 0; j < SizeY; j++)
            {
                var point = new Point(i, j);
                _fields[point] = new List<IMappable>();
            }
        }
    }
}