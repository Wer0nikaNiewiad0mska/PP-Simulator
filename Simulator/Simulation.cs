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

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished { get; private set; } = false;

    private int _turnCounter = 0;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[_turnCounter % Creatures.Count];

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
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");
        if (creatures.Count != positions.Count)
            throw new ArgumentException("The number of creatures must match the number of starting positions.");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        for (int i = 0; i < creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }
        Moves = string.Join("", DirectionParser.Parse(moves).Select(d => d.ToString()[0]));
    }
    /// <summary>
    /// Makes one move of current creature in current direction.
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

        CurrentCreature.Go(move);

        _turnCounter++;

        if (_turnCounter >= Moves.Length)
        {
            Finished = true;
        }
    }

}
