using AdventOfCode.Helpers;

namespace AdventOfCode.Year2023.Day02;

public class ElfCubeGameMinimumCubesCalculator
{
    public int GetMinimumCubesProductsSum(IEnumerable<string> games)
    {
        return games.Select(GetMinimumCubesProduct).Sum();
    }

    public int GetMinimumCubesProduct(string game)
    {
        var gameData = ElfCubeGameHelper.GetGameData(game);

        var requiredRedCount = 0;
        var requiredGreenCount = 0;
        var requiredBlueCount = 0;

        foreach (var gameSet in gameData.SplitFast(ElfCubeGameHelper.GameSetDelimiter))
        {
            foreach (var cubePull in gameSet.SplitFast(ElfCubeGameHelper.SetColorDelimiter))
            {
                var trimmed = cubePull.Trim();
                var color = ElfCubeGameHelper.GetCubeColor(trimmed);
                var number = ElfCubeGameHelper.GetCubeCount(trimmed);

                UpdateRequiredCubeCount(
                    color, 
                    number, 
                    ref requiredRedCount, 
                    ref requiredGreenCount,
                    ref requiredBlueCount);
            }
        }

        return requiredRedCount * requiredGreenCount * requiredBlueCount;
    }

    private static void UpdateRequiredCubeCount(
        ReadOnlySpan<char> color,
        int number,
        ref int requiredRedCount,
        ref int requiredGreenCount,
        ref int requiredBlueCount)
    {
        switch (color)
        {
            case "red":
                requiredRedCount = int.Max(requiredRedCount, number);
                break;
            case "green":
                requiredGreenCount = int.Max(requiredGreenCount, number);
                break;
            case "blue":
                requiredBlueCount = int.Max(requiredBlueCount, number);
                break;
        }
    }
}