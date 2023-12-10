namespace AdventOfCode.Year2023.Day08;

public class DayEightSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine($"Day 8 Part 1: {new PartOneAndTwo().PartOne(lines)}");
        Console.WriteLine($"Day 8 Part 2: {new PartOneAndTwo().PartTwo(lines)}");
    }
}