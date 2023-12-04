using AdventOfCode.Helpers;

namespace AdventOfCode.Year2023.Day02;

public class ElfCubeGameValidSum
{
    private readonly IDictionary<string, int> _bagCubeConfiguration;

    public ElfCubeGameValidSum(IDictionary<string, int> bagCubeConfiguration)
    {
        _bagCubeConfiguration = bagCubeConfiguration;
    }

    public int GetValidGameIdSum(IEnumerable<string> games)
    {
        return games.Where(IsValidGame).Select(GetGameIdNumber).Sum();
    }

    public bool IsValidGame(string game)
    {
        var gameData = ElfCubeGameHelper.GetGameData(game);

        foreach (var gameSet in gameData.SplitFast(ElfCubeGameHelper.GameSetDelimiter))
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
        foreach (var cubePull in gameSet.SplitFast(ElfCubeGameHelper.SetColorDelimiter))
        {
            var trimmed = cubePull.Trim();
            var color = ElfCubeGameHelper.GetCubeColor(trimmed);
            var number = ElfCubeGameHelper.GetCubeCount(trimmed);

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
        var gameId = gameLine.AsSpan()[..gameLine.IndexOf(ElfCubeGameHelper.GameNameAndDataDelimiter)];
        
        var idStartIndex = gameId.LastIndexOf(' ') + 1;
        var id = gameId[idStartIndex..];

        return int.Parse(id);
    }
}