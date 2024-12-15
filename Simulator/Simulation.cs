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
    private readonly SimulationHistory _history;

    public Map Map { get; }
    public List<IMappable> IMappables { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;
    private int _turnCounter = 0;

    public IMappable CurrentMappable => IMappables[_turnCounter % IMappables.Count];

    public string CurrentMoveName
    {
        get
        {
            var parsedMoves = DirectionParser.Parse(Moves);
            int validTurnCounter = _turnCounter % parsedMoves.Count;
            return parsedMoves[validTurnCounter].ToString().ToLower();
        }
    }

    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables == null || mappables.Count == 0)
            throw new ArgumentException("The list of mappables cannot be empty.", nameof(mappables));

        if (positions == null || positions.Count != mappables.Count)
            throw new ArgumentException("Number of starting positions must be the same as the number of mappables.", nameof(positions));

        if (string.IsNullOrEmpty(moves))
            throw new ArgumentException("Moves string cannot be null or empty.", nameof(moves));

        Map = map ?? throw new ArgumentNullException(nameof(map));
        IMappables = mappables;
        Positions = positions;
        Moves = new string(moves.Where(ch => "lrud".Contains(char.ToLower(ch))).ToArray());
        if (Moves.Length == 0)
            throw new ArgumentException("Moves string must contain at least one valid move ('l', 'r', 'u', 'd').");

        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
        }

        _history = new SimulationHistory(this);
    }

    public void Turn()
    {
        if (Finished) throw new InvalidOperationException("The simulation has finished.");

        var move = DirectionParser.Parse(Moves)[_turnCounter % Moves.Length];
        CurrentMappable.Go(move);
        _turnCounter++;

        if (_turnCounter >= Moves.Length) Finished = true;
    }

    public SimulationHistory History => _history;

    /// <summary>
    /// State of map after a single simulation turn.
    /// </summary>
    public class SimulationTurnLog
    {
        /// <summary>
        /// Text representation of moving object in this turn.
        /// CurrentMappable.ToString()
        /// </summary>
        public required string Mappable { get; init; }
        /// <summary>
        /// Text representation of move in this turn.
        /// CurrentMoveName.ToString()
        /// </summary>
        public required string Move { get; init; }
        /// <summary>
        /// Dictionary of IMappable.Symbol on the map in this turn.
        /// </summary>
        public required Dictionary<Point, char> Symbols { get; init; }
    }
}