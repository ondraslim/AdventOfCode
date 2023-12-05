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

        var location = sut.GetSeedWithClosestLocation(input);
        
        location.Should().Be(expectedLocation);
    }

    [Fact]
    public void SeedRangedLocationTestSimple()
    {
        var input =
            """
            seeds: 12 5

            map-1:
            50 12 5
            """;

        var lines = input.Split(Environment.NewLine);

        var sut = new SeedRangedLocationCalculator();

        var location = sut.GetSeedsRangedWithClosestLocation(lines);
        
        location.Should().Be(50);
    }

    [Fact]
    public void SeedRangedLocationTestSimple2()
    {
        var input =
            """
            seeds: 13 5

            map-1:
            50 12 5
            """;

        var lines = input.Split(Environment.NewLine);

        var sut = new SeedRangedLocationCalculator();

        var location = sut.GetSeedsRangedWithClosestLocation(lines);
        
        location.Should().Be(51);
    }

    [Fact]
    public void SeedRangedLocationTest()
    {
        var input =
            """
            seeds: 79 14 55 13

            seed-to-soil map:
            50 98 2
            52 50 48

            soil-to-fertilizer map:
            0 15 37
            37 52 2
            39 0 15

            fertilizer-to-water map:
            49 53 8
            0 11 42
            42 0 7
            57 7 4

            water-to-light map:
            88 18 7
            18 25 70

            light-to-temperature map:
            45 77 23
            81 45 19
            68 64 13

            temperature-to-humidity map:
            0 69 1
            1 0 69

            humidity-to-location map:
            60 56 37
            56 93 4
            """;

        var lines = input.Split(Environment.NewLine);

        var sut = new SeedRangedLocationCalculator();

        var location = sut.GetSeedsRangedWithClosestLocation(lines);
        
        location.Should().Be(46);
    }
}