namespace AdventOfCode.Year2023.Day09;

public class DayNineSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine($"Day 9 Part 1: {new PartOneAndTwo().PartOne(lines)}");
        Console.WriteLine($"Day 9 Part 2: {new PartOneAndTwo().PartTwo(lines)}");
    }
}