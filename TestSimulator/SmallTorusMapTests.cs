using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;
using Simulator.Maps;
using static Simulator.Directions;

namespace TestSimulator;

public class SmallTorusMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int sizeX = 10, sizeY = 10;
        var map = new SmallTorusMap(sizeX, sizeY);
        Assert.Equal(sizeX, map.SizeX);
        Assert.Equal(sizeY, map.SizeY);
    }

    [Theory]
    [InlineData(-1, 10)]
    [InlineData(10, -1)]
    [InlineData(-1, -1)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int sizeX, int sizeY)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallTorusMap(sizeX, sizeY));
    }

    [Theory]
    [InlineData(3, 4, 5, 5, true)]
    [InlineData(6, 1, 5, 5, false)]
    [InlineData(19, 19, 20, 20, true)]
    [InlineData(20, 20, 20, 20, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int sizeX, int sizeY, bool expected)
    {
        var map = new SmallTorusMap(sizeX, sizeY);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(9, 0, Direction.Right, 0, 0)]
    [InlineData(0, 9, Direction.Left, 9, 9)]
    [InlineData(5, 0, Direction.Down, 5, 9)]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallTorusMap(10, 10);
        var point = new Point(x, y);
        var nextPoint = map.Next(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(9, 0, Direction.Right, 0, 9)]
    [InlineData(0, 9, Direction.Left, 9, 0)]
    [InlineData(5, 0, Direction.Down, 4, 9)]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        var map = new SmallTorusMap(10, 10);
        var point = new Point(x, y);
        var nextPoint = map.NextDiagonal(point, direction);
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}