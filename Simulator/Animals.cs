using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";
    public required string Description 
    { 
        get => description;
        init => description = Validator.Shortener(value, 3, 15, '#');
    }
    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public Point Position => throw new NotImplementedException();

    public void Go(Directions.Direction move)
    {
        throw new NotImplementedException();
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        throw new NotImplementedException();
    }

    public override string ToString()
    {
        return $"{GetType().Name.ToUpper()}: {Info}";
    }
}
