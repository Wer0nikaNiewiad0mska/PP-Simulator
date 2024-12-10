using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;
using static Simulator.Directions;

namespace Simulator;

public class SimulationHistory
{
    private readonly List<SimulationSnapshot> _history = new();

    public void AddSnapshot(Simulation simulation)
    {
        var snapshot = new SimulationSnapshot(simulation);
        _history.Add(snapshot);
    }

    public SimulationSnapshot GetSnapshot(int turn)
    {
        if (turn < 1 || turn > _history.Count)
            throw new ArgumentOutOfRangeException(nameof(turn), "Invalid turn number.");

        return _history[turn - 1];
    }

    public int TotalTurns => _history.Count;
}

public class SimulationSnapshot
{
    public List<IMappable> Mappables { get; }
    public List<Point> Positions { get; }
    public string CurrentMove { get; }
    public IMappable CurrentMappable { get; }

    public SimulationSnapshot(Simulation simulation)
    {
        Mappables = simulation.IMappables.Select(m => m).ToList();
        Positions = simulation.IMappables.Select(m => m.Position).ToList();
        CurrentMove = simulation.CurrentMoveName;
        CurrentMappable = simulation.CurrentMappable;
    }

    public void DisplaySnapshot()
    {
        Console.WriteLine($"Current Turn: {CurrentMappable.Info} moves {CurrentMove}");
        Console.WriteLine("Map state:");
        for (int i = 0; i < Mappables.Count; i++)
        {
            Console.WriteLine($"{Mappables[i].Symbol} at {Positions[i]}");
        }
    }
}