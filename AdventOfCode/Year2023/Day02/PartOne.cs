﻿using AdventOfCode.Helpers;

namespace AdventOfCode.Year2023.Day02;

public class PartOne
{
    private readonly IDictionary<string, int> _bagCubeConfiguration;

    public PartOne(IDictionary<string, int> bagCubeConfiguration)
    {
        _bagCubeConfiguration = bagCubeConfiguration;
    }

    public int Run(IEnumerable<string> games)
    {
        return games.Where(IsValidGame).Select(GetGameIdNumber).Sum();
    }

    public bool IsValidGame(string game)
    {
        var gameData = Helpers.GetGameData(game);

        foreach (var gameSet in gameData.SplitFast(Helpers.GameSetDelimiter))
        {
            if (!IsValidSet(gameSet))
            {
                return false;
            }
        }

        return true;
    }

    private bool IsValidSet(ReadOnlySpan<char> gameSet)
    {
        foreach (var cubePull in gameSet.SplitFast(Helpers.SetColorDelimiter))
        {
            var trimmed = cubePull.Trim();
            var color = Helpers.GetCubeColor(trimmed);
            var number = Helpers.GetCubeCount(trimmed);

            if (_bagCubeConfiguration.TryGetValue(color, out var maxAllowedCount)
                && number > maxAllowedCount)
            {
                return false;
            }
        }

        return true;
    }

    private static int GetGameIdNumber(string gameLine)
    {
        var gameId = gameLine.AsSpan()[..gameLine.IndexOf(Helpers.GameNameAndDataDelimiter)];
        
        var idStartIndex = gameId.LastIndexOf(' ') + 1;
        var id = gameId[idStartIndex..];

        return int.Parse(id);
    }
}