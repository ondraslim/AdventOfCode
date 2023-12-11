using AdventOfCode.Year2023.Day09;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day09;

public class PartOneAndTwoTests
{
    [Theory]
    [InlineData("1 3 6 10 15 21", 28)]
    [InlineData("10 13 16 21 30 45", 68)]
    public void PartOne(string input, long expectedValue)
    {

        var sut = new PartOneAndTwo();

        var extrapolatedValue = sut.PartOne(new[] { input });

        extrapolatedValue.Should().Be(expectedValue);
    }

    [Theory]
    [InlineData("0 3 6 9 12 15", -3)]
    [InlineData("1 3 6 10 15 21", 0)]
    [InlineData("10 13 16 21 30 45", 5)]
    public void PartTwo(string input, long expectedValue)
    {
        var sut = new PartOneAndTwo();

        var extrapolatedValue = sut.PartTwo(new[] { input });

        extrapolatedValue.Should().Be(expectedValue);
    }
}