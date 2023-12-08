namespace AdventOfCode.Year2023.Day05;

public class DayFiveSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine($"Day 5 Part 1: {new PartOne().Run(lines)}");
        Console.WriteLine($"Day 5 Part 2: {new PartTwo().Run(lines)}");
    }
}
