using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
    {
        FNext = MoveRules.BounceNext;
        FNextDiagonal = MoveRules.BounceNextDiagonal;
    }

    
}
