using AdventOfCode.Year2023.Day05;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day05;

public class SeedLocationCalculatorTests
{
    [Theory]
    [InlineData(79, 81)]
    [InlineData(14, 14)]
    [InlineData(55, 57)]
    [InlineData(13, 13)]
    public void SeedLocationTest(int seed, int expectedLocation)
    {
        var input = new string[]
        {
            $"seeds: {seed}",
            "  ",
            "map-1",
            "50 98 2",
            "52 50 48",
        };

        var sut = new SeedLocationCalculator();

        var location = sut.GetSeedWithClosesLocation(input);
        
        location.Should().Be(expectedLocation);
    }
}