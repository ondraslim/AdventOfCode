using System.Globalization;

namespace AdventOfCode.Year2023.Day01;

public class PartOne
{
    public int Run(IEnumerable<string> lines)
    {
        return lines.Select(Run).Sum();
    }

    public int Run(string text)
    {
        int? firstNumber = null;
        int? lastNumber = null;

        var textDigits = text.Where(char.IsDigit).Select(CharUnicodeInfo.GetDigitValue);
        
        foreach (var number in textDigits)
        {
            firstNumber ??= number;
            lastNumber = number;
        }

        if (firstNumber.HasValue && lastNumber.HasValue)
        {
            return firstNumber.Value * 10 + lastNumber.Value;
        }
        
        return 0;
    }
}
