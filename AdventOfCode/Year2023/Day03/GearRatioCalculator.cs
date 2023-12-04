using System.Buffers;
using AdventOfCode.Helpers;

namespace AdventOfCode.Year2023.Day03;

public class GearRatioCalculator
{
    public int Calculate(string[] schemaLines)
    {
        var result = 0;

        for (var i = 0; i < schemaLines.Length; i++)
        {
            var line = schemaLines[i];
            for (var j = 0; j < line.Length; j++)
            {
                if (line[j] is '*')
                {
                    result += GetGearRatio(schemaLines, i, j);
                }
            }
        }

        return result;
    }

    private static int GetGearRatio(string[] schemaLines, int lineIndex, int currentIndex)
    {
        var adjacentNumbers = ArrayPool<int>.Shared.Rent(2);
        var foundCount = 0;

        var neighboringLines = Enumerable.Range(lineIndex - 1, 3)
            .Where(i => 0 <= i && i < schemaLines.Length)
            .Select(i => schemaLines[i]);

        foreach (var line in neighboringLines)
        {
            for (var i = currentIndex - 1; i <= currentIndex + 1; i++)
            {
                if (line.IsIndexValid(i))
                {
                    if (char.IsDigit(line[i]))
                    {
                        if (foundCount == 2)
                        {
                            ArrayPool<int>.Shared.Return(adjacentNumbers);
                            return 0;
                        }

                        var adjacentNumber = GetNumber(line, ref i);
                        adjacentNumbers[foundCount] = adjacentNumber;
                        foundCount++;
                    }
                }
            }
        }

        if (foundCount == 2)
        {
            ArrayPool<int>.Shared.Return(adjacentNumbers);
            return adjacentNumbers[0] * adjacentNumbers[1];
        }

        ArrayPool<int>.Shared.Return(adjacentNumbers);
        return 0;
    }

    private static int GetNumber(ReadOnlySpan<char> line, ref int index)
    {
        var numberStartIndex = GetNumberStartIndex(line, index);
        var numberEndIndex = GetNumberEndIndex(line, index);
        index = numberEndIndex;

        return int.Parse(line[numberStartIndex..numberEndIndex]);
    }

    private static int GetNumberStartIndex(ReadOnlySpan<char> line, int index)
    {
        while (index - 1 >= 0 && char.IsDigit(line[index - 1]))
        {
            index--;
        }

        return index;
    }

    private static int GetNumberEndIndex(ReadOnlySpan<char> line, int index)
    {
        while (index < line.Length && char.IsDigit(line[index]))
        {
            index++;
        }

        return index;
    }
}