namespace AdventOfCode.Year2023.Day04;

public class DayFourSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        var partsOneAndTwo = new PartOneAndTwo();

        Console.WriteLine($"Day 4 Part 1: {partsOneAndTwo.RunPartOne(lines)}");
        Console.WriteLine($"Day 4 Part 2: {partsOneAndTwo.RunPartTwo(lines)}");
    }
}
