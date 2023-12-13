namespace AdventOfCode.Year2023.Day06;

public class DaySixSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine($"Day 6 Part 1: {new PartOneAndTwo().PartOne(lines)}");
        Console.WriteLine($"Day 6 Part 2: {new PartOneAndTwo().PartTwo(lines)}");
    }
}