using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator.Maps;
using Simulator;
using System.Linq;

namespace SimWeb.Pages;

public class IndexModel : PageModel
{
    private static SimulationHistory _history;
    private static int _currentTurn = 0;

    public int GridWidth => _history?.SizeX ?? 8;
    public int GridHeight => _history?.SizeY ?? 6;

    public int CurrentTurn => _currentTurn;
    public SimulationTurnLog CurrentTurnLog => _history?.TurnLogs[_currentTurn];
    public Point CurrentPosition => CurrentTurnLog?.Symbols.Keys.FirstOrDefault() ?? new Point(0, 0);

    public void OnGet()
    {
        if (_history == null)
            InitializeSimulation();
    }

    public void OnPost(string action)
    {
        if (_history == null)
            InitializeSimulation();

        if (action == "next" && _currentTurn < _history.TurnLogs.Count - 1)
            _currentTurn++;
        else if (action == "previous" && _currentTurn > 0)
            _currentTurn--;
    }

    private void InitializeSimulation()
    {
        var map = new BigBounceMap(8, 6);
        var creatures = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals { Description = "Króliki", Size = 11 },
            new Birds { Description = "Orły", Size = 3 },
            new Birds { Description = "Strusie", CanFly = false }
        };
        var positions = new List<Point>
        {
            new(2, 2), new(3, 1), new(5, 2), new(6, 0), new(6, 3)
        };
        var moves = "dlrludlldrluuduldurr";

        var simulation = new Simulation(map, creatures, positions, moves);
        _history = simulation.History;
    }

    public string GetSymbolAt(int x, int y)
    {
        var position = new Point(x, y);
        if (CurrentTurnLog?.Symbols.ContainsKey(position) == true)
        {
            var mappablesAtPosition = CurrentTurnLog.Symbols.Where(pair => pair.Key.Equals(position)).ToList();

            if (mappablesAtPosition.Count > 1)
            {
                return "/images/war.png";
            }
            else
            {
                var symbol = mappablesAtPosition.First().Value.ToString(); 

                switch (symbol)
                {
                    case "O":
                        return "/images/orc.png";
                    case "E":
                        return "/images/elf.png";
                    case "A":
                        return "/images/rabbit.png";
                    case "B":
                        return "/images/bird.png";
                    case "b":
                        return "/images/ostrich.png";
                    default:
                        return "";
                }
            }
        }
        return "";
    }
}
