using AdventOfCode.Year2023.Day06;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day06;

public class PartOneAndTwoTests
{
    [Theory]
    [InlineData(
        """
        Time: 7
        Distance: 9
        """,
        4)]
    [InlineData(
        """
        Time: 15
        Distance: 40 
        """, 
        8)]
    [InlineData(
        """
        Time: 30
        Distance: 200 
        """, 
        9)]
    public void PartOne(string input, long expectedValue)
    {
        var lines = input.Split(Environment.NewLine);
        var sut = new PartOneAndTwo();

        var count = sut.PartOne(lines);

        count.Should().Be(expectedValue);
    }
}