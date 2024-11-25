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
        int sizeX = 15, sizeY = 15;
        var map = new SmallSquareMap(sizeX, sizeY);
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }

    [Theory]
    [InlineData(-1, 15)]
    [InlineData(15, -1)]
    [InlineData(-1, -1)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int sizeX, int sizeY)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(sizeX, sizeY));
    }

    [Theory]
    [InlineData(2, 3, 6, 6, true)]
    [InlineData(7, 7, 6, 6, false)]
    [InlineData(0, 0, 8, 8, true)]
    [InlineData(8, 8, 8, 8, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int sizeX, int sizeY, bool expected)
    {
        var map = new SmallSquareMap(sizeX, sizeY);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 7, Direction.Up, 5, 8)]
    [InlineData(6, 6, Direction.Down, 6, 5)]
    [InlineData(5, 8, Direction.Left, 4, 8)]
    [InlineData(3, 2, Direction.Right, 4, 2)]
    [InlineData(9, 9, Direction.Up, 9, 9)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(10, 10);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 6, 6)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    [InlineData(5, 5, Direction.Left, 4, 6)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(0, 0, Direction.Left, 0, 0)]
    [InlineData(7, 7, Direction.Up, 7, 7)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallSquareMap(8, 8);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
