using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator;

namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 1, 10, 5)]
    [InlineData(0, 1, 10, 1)]
    [InlineData(15, 1, 10, 10)]
    [InlineData(10, 1, 10, 10)]
    [InlineData(1, 1, 10, 1)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Hello", 5, 10, ' ', "Hello")]
    [InlineData("Hi", 5, 10, ' ', "Hi   ")]
    [InlineData("This is a very long string", 5, 10, '.', "This is a")]
    [InlineData("Short", 5, 10, '.', "Short")]
    [InlineData("Trim this    ", 5, 10, '_', "Trim this")]
    [InlineData("   Tiny   ", 5, 5, '_', "Tiny_")]
    [InlineData("   Long String That Should Be Trimmed    ", 10, 15, '.', "Long String Tha")]
    public void Shortener_ShouldReturnCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("     ", 5, 10, '.', ".....")]
    [InlineData("         ", 5, 10, '_', "_____")]
    [InlineData("   ", 5, 5, '_', "_____")]
    [InlineData("      ", 5, 5, '#', "#####")]
    [InlineData("       ", 5, 10, '_', "_____")]
    public void Shortener_ShouldHandleSpacesCorrectly(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("hello", 5, 10, '_', "Hello")]
    [InlineData("hi", 5, 10, '_', "Hi___")]
    [InlineData("this is a test", 5, 10, '.', "This is a")]
    [InlineData("small", 5, 10, '_', "Small")]
    [InlineData("a", 5, 10, '_', "A____")]
    [InlineData("test this string", 5, 5, '.', "Test.")]
    public void Shortener_ShouldCapitalizeFirstLetterWhenNeeded(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
}

