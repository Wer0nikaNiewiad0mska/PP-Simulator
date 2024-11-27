using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Simulator.Directions;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }
    public List<IMappable> IMappables { get; private set; }

    /// <summary>
    /// IMappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private int _turnCounter = 0;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable => Mappables[_turnCounter % Mappables.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            var parsedMoves = DirectionParser.Parse(Moves);
             int validTurnCounter = _turnCounter % parsedMoves.Count;
            return parsedMoves[validTurnCounter].ToString().ToLower();
        }
    }

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables,
        List<Point> positions, string moves)
    {
        if (mappables.Count == 0)
            throw new ArgumentException("IMappables list cannot be empty.");
        if (mappables.Count != positions.Count)
            throw new ArgumentException("The number of mappables must match the number of starting positions.");

        Map = map;
        IMappables = mappables;
        Positions = positions;
        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(Map, Positions[i]);
        }
        Moves = string.Join("", DirectionParser.Parse(moves).Select(d => d.ToString()[0]));
    }
    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() {
        if (Finished)
        {
            throw new InvalidOperationException("The simulation has finished.");
        }
        if (_turnCounter >= Moves.Length)
        {
            Finished = true;
            return;
        }

        var move = DirectionParser.Parse(Moves)[_turnCounter];

        CurrentMappable.Go(move);

        _turnCounter++;

        if (_turnCounter >= Moves.Length)
        {
            Finished = true;
        }
    }

}
