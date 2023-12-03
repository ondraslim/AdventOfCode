using System.Buffers;
using AdventOfCode.Helpers;

namespace AdventOfCode;

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
                    if (TryGetGearRatio(schemaLines, i, j, out var number))
                    {
                        result += number;
                    }
                }
            }
        }

        return result;
    }

    private bool TryGetGearRatio(string[] schemaLines, int lineIndex, int currentIndex, out int ratio)
    {
        var adjacentNumbers = ArrayPool<int>.Shared.Rent(2);
        var foundCount = 0;
        
        foreach (var lineShift in Enumerable.Range(lineIndex - 1, 3).Where(i => 0 <= i && i < schemaLines.Length))
        {
            var currentLine = schemaLines[lineShift].AsSpan();
            for (var i = currentIndex - 1; i <= currentIndex + 1; i++)
            {
                if (currentLine.Length > i && i >= 0)
                {
                    var character = currentLine[i];
                    if (char.IsDigit(character))
                    {
                        if (foundCount == 2)
                        {
                            break;
                        }

                        var adjacentNumber = GetNumber(currentLine, ref i);
                        adjacentNumbers[foundCount] = adjacentNumber;
                        foundCount++;
                    }
                }
            }

            if (foundCount == 2)
            {
                break;
            }
        }

        if (foundCount == 2)
        {
            ratio = adjacentNumbers[0] * adjacentNumbers[1];
            ArrayPool<int>.Shared.Return(adjacentNumbers);
            return true;
        }

        ArrayPool<int>.Shared.Return(adjacentNumbers);
        ratio = 0;
        return false;
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