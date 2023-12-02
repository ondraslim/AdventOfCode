using System.Globalization;

namespace AdventOfCode;

public class CalibrationValueSpelledDecoder
{
    private static readonly Dictionary<string, int> SpelledNumbersMap = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 },
    };

    public int SumDecoded(IEnumerable<string> lines)
    {
        return lines.Select(Decode).Sum();
    }

    public int Decode(string text)
    {
        int? firstNumber = null;
        int? lastNumber = null;

        var textSpan = text.AsSpan();

        for (var i = 0; i < textSpan.Length; i++)
        {
            if (char.IsDigit(textSpan[i]))
            {
                var number = CharUnicodeInfo.GetDigitValue(textSpan[i]);
                firstNumber ??= number;
                lastNumber = number;
            }
            else if (TryGetSpelledNumber(textSpan[i..], out var number))
            {
                firstNumber ??= number;
                lastNumber = number;
            }
        }

        if (firstNumber.HasValue && lastNumber.HasValue)
        {
            return firstNumber.Value * 10 + lastNumber.Value;
        }

        return 0;
    }

    private static bool TryGetSpelledNumber(ReadOnlySpan<char> span, out int number)
    {
        foreach (var spelledNumber in SpelledNumbersMap.Keys)
        {
            if (span.StartsWith(spelledNumber))
            {
                number = SpelledNumbersMap[spelledNumber];
                return true;
            }
        }

        number = -1;
        return false;
    }
}