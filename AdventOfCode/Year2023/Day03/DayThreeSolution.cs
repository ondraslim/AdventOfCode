namespace AdventOfCode.Year2023.Day03;

public class DayThreeSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine($"Day 3 Part 1: {new PartOne().Run(lines)}");
        Console.WriteLine($"Day 3 Part 2: {new PartTwo().Run(lines)}");
    }
}
