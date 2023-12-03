namespace AdventOfCode;

public class CalibrationValuesSolution : ITaskSolution
{
    public void Run()
    {
        var file = Path.Combine("2023", "01", "input01.txt");
        var lines = File.ReadAllLines(file);
        var sum = new CalibrationValueDecoder().SumDecoded(lines);
        
        Console.WriteLine(sum);
    }
}

public class CalibrationValuesSpelledSolution : ITaskSolution
{
    public void Run()
    {
        var file = Path.Combine("2023", "01", "input01.txt");
        var lines = File.ReadAllLines(file);
        var sum = new CalibrationValueSpelledDecoder().SumDecoded(lines);

        Console.WriteLine(sum);
    }
}