using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public interface IMappable
{
    string Info { get; }
    Point Position { get; }
    void Go(Directions.Direction move);
    void InitMapAndPosition(Map map, Point point);
}
