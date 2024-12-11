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
    private readonly SimulationHistory _history;
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
    public IMappable CurrentMappable => IMappables[_turnCounter % IMappables.Count];

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

    public IMappable CurrentMove { get; set; }

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
        if (mappables == null || mappables.Count == 0) throw new ArgumentException("The list of mappables cannot be empty.", nameof(positions));
        if (positions == null || positions.Count != mappables.Count) throw new ArgumentException("Number of starting positions must be the same as the number of mappables.", nameof(positions));
        if (string.IsNullOrEmpty(moves)) throw new ArgumentException("Moves string cannot be null or empty.", nameof(moves));

        Map = map ?? throw new ArgumentNullException(nameof(map));
        IMappables = mappables;
        Positions = positions;
        //Moves = moves.ToLower();
        Moves = new string(moves.Where(ch => "lrud".Contains(char.ToLower(ch))).ToArray());
        if (Moves.Length == 0)
            throw new ArgumentException("Moves string must contain at least one valid move ('l', 'r', 'u', 'd').");

        for (int i = 0; i < mappables.Count; i++)
        {
            mappables[i].InitMapAndPosition(map, positions[i]);
        }
    }
    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    /// <summary>
    /// State of map after single simulation turn.
    /// </summary>
    public class SimulationTurnLog
    {
        /// <summary>
        /// Text representastion of moving object in this turn.
        /// CurrentMappable.ToString()
        /// </summary>
        public required string Mappable { get; init; }
        /// <summary>
        /// Text representation of move in this turn.
        /// CurrentMoveName.ToString();
        /// </summary>
        public required string Move { get; init; }
        /// <summary>
        /// Dictionary of IMappable.Symbol on the map in this turn.
        /// </summary>
        public required Dictionary<Point, char> Symbols { get; init; }
    }
}
