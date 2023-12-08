namespace AdventOfCode.Year2023.Day03;

public class PartOne
{
    public int Run(string[] schemaLines)
    {
        var result = 0;

        for (var i = 0; i < schemaLines.Length; i++)
        {
            var line = schemaLines[i];
            for (var j = 0; j < line.Length; j++)
            {
                if (char.IsDigit(line[j]) 
                    && TryGetEnginePartNumber(schemaLines, i, ref j, out var number))
                {
                    result += number;
                }
            }
        }

        return result;
    }

    private static bool TryGetEnginePartNumber(IReadOnlyList<string> schemaLines, int lineIndex, ref int currentIndex, out int number)
    {
        var line = schemaLines[lineIndex].AsSpan();

        var numberEndIndex = GetNumberEndIndex(line, currentIndex);
        var coordinates = GetNumberNeighborCoordinates(lineIndex, currentIndex, numberEndIndex);
        
        if (coordinates.Where(c => IsValidCoordinate(c, schemaLines))
            .Any(coordinate => IsSymbolAt(coordinate.i, coordinate.j, schemaLines)))
        {
            number = int.Parse(line[currentIndex..numberEndIndex]);
            currentIndex = numberEndIndex;
            return true;
        }

        number = 0;
        return false;
    }

    private static int GetNumberEndIndex(ReadOnlySpan<char> line, int numberStartIndex)
    {
        var numberEndIndex = 0;
        
        for (var i = numberStartIndex; i < line.Length; i++)
        {
            if (!char.IsDigit(line[i]))
            {
                break;
            }

            numberEndIndex = i + 1;
        }

        return numberEndIndex;
    }

    private static IEnumerable<(int i, int j)> GetNumberNeighborCoordinates(
        int lineIndex, 
        int numberStartIndex,
        int numberEndIndex)
    {
        for (var i = lineIndex - 1; i <= lineIndex + 1; i++)
        {
            for (var j = numberStartIndex - 1; j < numberEndIndex + 1; j++)
            {
                yield return (i, j);
            }
        }
    }

    private static bool IsValidCoordinate((int i, int j) coordinates, IReadOnlyList<string> schemaLines)
    {
        return 0 <= coordinates.i && coordinates.i < schemaLines.Count 
            && 0 <= coordinates.j && coordinates.j < schemaLines[coordinates.i].Length;
    }

    private static bool IsSymbolAt(int i, int j, IReadOnlyList<string> schemaLines)
    {
        var character = schemaLines[i][j];
        return !char.IsDigit(character) && character != '.';
    }
}