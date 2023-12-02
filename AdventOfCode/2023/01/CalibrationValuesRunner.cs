namespace AdventOfCode;

public interface ICalibrationValuesCalculator
{
    int GetCalibrationValuesSum(IEnumerable<string> lines);
    int GetCalibrationValue(string text);
}

public static class CalibrationValuesRunner
{
    private static readonly string InputFile;
    private static readonly ICalibrationValuesCalculator CalibrationValuesSum;

    static CalibrationValuesRunner()
    {
        InputFile = Path.Combine("2023", "01", "input.txt");
        //CalibrationValuesSum = new CalibrationValuesSum();
        CalibrationValuesSum = new CalibrationValuesSpelledCalculator();
    }

    public static int Run()
    {
        var lines = File.ReadAllLines(InputFile);
        return CalibrationValuesSum.GetCalibrationValuesSum(lines);
    }
}