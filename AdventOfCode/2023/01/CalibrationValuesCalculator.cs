using System.Globalization;

namespace AdventOfCode;

public class CalibrationValuesCalculator : ICalibrationValuesCalculator
{
    public int GetCalibrationValuesSum(IEnumerable<string> lines)
    {
        return lines.Select(GetCalibrationValue).Sum();
    }

    public int GetCalibrationValue(string text)
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
