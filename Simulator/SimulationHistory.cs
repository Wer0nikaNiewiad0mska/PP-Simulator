using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;
using static Simulator.Directions;
using static Simulator.Simulation;

namespace Simulator;

public class SimulationHistory
{
    private readonly Simulation _simulation;
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = new();

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    private void Run()
    {
        LogTurn();

        while (!_simulation.Finished)
        {
            _simulation.Turn();
            LogTurn();
        }
    }

    private void LogTurn()
    {
        var symbols = new Dictionary<Point, char>();

        foreach (var mappable in _simulation.IMappables)
        {
            symbols[mappable.Position] = mappable.Symbol;
        }

        TurnLogs.Add(new SimulationTurnLog
        {
            Mappable = _simulation.CurrentMappable.ToString(),
            Move = _simulation.CurrentMoveName,
            Symbols = symbols
        });
    }
}