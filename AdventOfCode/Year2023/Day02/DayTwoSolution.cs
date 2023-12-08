namespace AdventOfCode.Year2023.Day02;

public class DayTwoSolution : ITaskSolution
{
    public void Run()
    {
        var cubeBagConfiguration = new Dictionary<string, int>
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 },
        };

        var lines = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine($"Day 2 Part 1: {new PartOne(cubeBagConfiguration).Run(lines)}");
        Console.WriteLine($"Day 2 Part 2: {new PartTwo().Run(lines)}");
    }
}