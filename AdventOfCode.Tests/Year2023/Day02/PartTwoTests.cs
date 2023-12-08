using AdventOfCode.Year2023.Day02;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day02;

public class PartTwoTests
{
    public static IEnumerable<object[]> TestGames = new List<object[]>
    {
        new object[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48 },
        new object[] { "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12 },
        new object[] { "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560 },
        new object[] { "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630 },
        new object[] { "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36 },
    };
    
    [Theory]
    [MemberData(nameof(TestGames))]
    public void MinimumRequiredCubeCountsTests(string gameLine, int expectedSum)
    {
        var sut = new PartTwo();

        var minimumCubesProductsSum = sut.GetMinimumCubesProduct(gameLine);

        minimumCubesProductsSum.Should().Be(expectedSum);
    }

    [Fact]
    public void MinimumRequiredCubeCountSumTest()
    {
        var games = new[]
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };

        var sut = new PartTwo();

        var minimumCubesProductsSum = sut.Run(games);

        minimumCubesProductsSum.Should().Be(2286);
    }
}