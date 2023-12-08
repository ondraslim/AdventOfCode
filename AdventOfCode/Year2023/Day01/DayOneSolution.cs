namespace AdventOfCode.Year2023.Day01;

public class DayOneSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine($"Day 1 Part 1: {new PartOne().Run(lines)}");
        Console.WriteLine($"Day 1 Part 2: {new PartTwo().Run(lines)}");
    }
}
