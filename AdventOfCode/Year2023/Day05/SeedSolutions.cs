namespace AdventOfCode.Year2023.Day05;

public class SeedSolutions : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine(new SeedLocationCalculator().GetSeedWithClosesLocation(lines));
    }
}
