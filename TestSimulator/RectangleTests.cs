using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace TestSimulator;

public class RectangleTests
{
    [Theory]
    [InlineData(1, 2, 3, 4, "(1, 2):(3, 4)")]
    [InlineData(0, 0, 6, 6, "(0, 0):(6, 6)")]
    [InlineData(-10, -5, 5, 10, "(-10, -5):(5, 10)")]
    [InlineData(0, 0, 10, 10, "(0, 0):(10, 10)")]
    [InlineData(5, 5, 1, 1, "(1, 1):(5, 5)")]
    public void Rectangle_ValidPoints_ShouldReturnExpected(int x1, int y1, int x2, int y2, string expected)
    {
        var rect = new Rectangle(x1, y1, x2, y2);
        var result = rect.ToString();
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 0, 10)]
    [InlineData(0, 0, 10, 0)]
    [InlineData(1, 1, 1, 5)]
    [InlineData(5, 5, 5, 5)]
    [InlineData(-4, -4, -2, -4)]
    public void Constructor_InvalidRectangle_ShouldThrowArgumentException(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Theory]
    [InlineData(5, 5, 1, 1)]
    [InlineData(1, 1, 5, 5)]
    [InlineData(-5, -5, 5, 5)]
    [InlineData(0, 0, 10, 10)]
    [InlineData(5, 0, 0, 5)]
    public void Constructor_ShouldFlipCoordinatesIfNeeded(int x1, int y1, int x2, int y2)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        Assert.True(rectangle.X1 <= rectangle.X2);
        Assert.True(rectangle.Y1 <= rectangle.Y2);
    }

    [Theory]
    [InlineData(1, 1, 3, 5, 2, 3, true)]
    [InlineData(1, 1, 3, 5, 4, 6, false)]
    [InlineData(1, 1, 3, 5, 1, 5, true)]
    [InlineData(1, 1, 3, 5, 3, 1, true)]
    [InlineData(0, 0, 10, 10, 5, 5, true)]
    [InlineData(0, 0, 10, 10, 0, 0, true)]
    [InlineData(0, 0, 10, 10, 10, 10, true)]
    [InlineData(0, 0, 10, 10, -1, -1, false)]
    [InlineData(0, 0, 10, 10, 11, 5, false)]
    [InlineData(0, 0, 10, 10, 5, 11, false)]
    public void Contains_ShouldReturnCorrectValue(int x1, int y1, int x2, int y2, int px, int py, bool expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var point = new Point(px, py);
        var result = rectangle.Contains(point);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 0, 10, 10, "(0, 0):(10, 10)")]
    [InlineData(5, 5, 1, 1, "(1, 1):(5, 5)")]
    [InlineData(-10, -5, 5, 10, "(-10, -5):(5, 10)")]
    public void ToString_ShouldReturnCorrectFormat(int x1, int y1, int x2, int y2, string expected)
    {
        var rectangle = new Rectangle(x1, y1, x2, y2);
        var result = rectangle.ToString();
        Assert.Equal(expected, result);
    }
}

