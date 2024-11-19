using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using static Simulator.Directions;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void ToString_ShouldReturnCorrectFormat()
    {
        var point = new Point(5, 10);
        Assert.Equal("(5, 10)", point.ToString());
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 5, 6)]
    [InlineData(5, 5, Direction.Down, 5, 4)]
    [InlineData(5, 5, Direction.Left, 4, 5)]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.Next(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 6, 6)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    [InlineData(5, 5, Direction.Left, 4, 6)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(0, 0, Direction.Right, 1, -1)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(0, 0, Direction.Left, -1, 1)]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var point = new Point(x, y);
        var nextPoint = point.NextDiagonal(direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
