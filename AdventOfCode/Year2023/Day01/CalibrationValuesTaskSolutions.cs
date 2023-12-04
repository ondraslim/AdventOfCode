namespace AdventOfCode.Year2023.Day01;

public class CalibrationValuesSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);
        var sum = new CalibrationValueDecoder().SumDecoded(lines);
        
        Console.WriteLine(sum);
    }
}

public class CalibrationValuesSpelledSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);
        var sum = new CalibrationValueSpelledDecoder().SumDecoded(lines);

        Console.WriteLine(sum);
    }
}