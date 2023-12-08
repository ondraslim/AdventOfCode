namespace AdventOfCode.Year2023.Day02;

public static class Helpers
{
    public const char GameNameAndDataDelimiter = ':';
    public const string GameSetDelimiter = ";";
    public const string SetColorDelimiter = ",";
    
    public static ReadOnlySpan<char> GetGameData(string gameLine)
    {
        var gameDataStartIndex = gameLine.IndexOf(GameNameAndDataDelimiter) + 1;
        return gameLine.AsSpan()[gameDataStartIndex..];
    }

    public static ReadOnlySpan<char> GetCubeColor(ReadOnlySpan<char> trimmed)
    {
        var colorAndCountSeparatorIndex = trimmed.IndexOf(' ');
        return trimmed[colorAndCountSeparatorIndex..].Trim();
    }

    public static int GetCubeCount(ReadOnlySpan<char> trimmed)
    {
        var colorAndCountSeparatorIndex = trimmed.IndexOf(' ');
        var numberText = trimmed[..colorAndCountSeparatorIndex].Trim();
        return int.Parse(numberText);
    }
}