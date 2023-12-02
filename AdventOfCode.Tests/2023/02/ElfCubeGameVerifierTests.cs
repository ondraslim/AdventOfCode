using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests;

public class ElfCubeGameVerifierTests
{
    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 5 blue; 2 green", true)]
    [InlineData("Game 1: 15 blue, 4 red; 1 red, 2 green, 4 blue; 2 green", false)]
    [InlineData("Game 1: 3 blue, 4 red; 11 red, 2 green, 4 blue; 2 green", false)]
    [InlineData("Game 1: 3 blue, 4 red; 11 red, 2 green, 4 blue; 11 green", false)]
    public void GameValidityTests(string gameLine, bool expectValidity)
    {
        var elfGames = new ElfCubeGameValidSum(new Dictionary<string, int>
        {
            { "red", 10 },
            { "green", 10 },
            { "blue", 5 },
        });

        var isValidGame = elfGames.IsValidGame(gameLine);

        isValidGame.Should().Be(expectValidity);
    }

    [Fact]
    public void ValidGameSumTest()
    {
        var input = new[]
        {
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green",
        };

        var elfGames = new ElfCubeGameValidSum(new Dictionary<string, int>
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 },
        });

        var validGameIdSum = elfGames.GetValidGameIdSum(input);

        validGameIdSum.Should().Be(8);
    }
}