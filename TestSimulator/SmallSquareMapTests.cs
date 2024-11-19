using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;
using Simulator;
using static Simulator.Directions;
namespace TestSimulator;
public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int size = 15;
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(2, 3, 6, true)]
    [InlineData(7, 7, 6, false)]
    [InlineData(0, 0, 8, true)]
    [InlineData(8, 8, 8, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 7, Direction.Up, 5, 8)]
    [InlineData(6, 6, Direction.Down, 6, 5)]
    [InlineData(5, 8, Direction.Left, 4, 8)]
    [InlineData(3, 2, Direction.Right, 4, 2)]
    [InlineData(19, 19, Direction.Up, 19, 19)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(19, 19, Direction.Right, 19, 19)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(10);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 10, Direction.Up, 6, 11)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    [InlineData(4, 8, Direction.Left, 3, 9)]
    [InlineData(10, 10, Direction.Right, 11, 9)]
    [InlineData(19, 19, Direction.Up, 19, 19)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(19, 19, Direction.Right, 19, 19)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y,
        Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(20);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
