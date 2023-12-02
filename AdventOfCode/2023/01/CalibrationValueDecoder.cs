using System.Globalization;

namespace AdventOfCode;

public class CalibrationValueDecoder
{
    public int SumDecoded(IEnumerable<string> lines)
    {
        return lines.Select(Decode).Sum();
    }

    public int Decode(string text)
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
