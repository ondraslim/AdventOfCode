namespace AdventOfCode.Year2023.Day02;

public class ElfGameValidIdSumSolution : ITaskSolution
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
        var sum = new ElfCubeGameValidSum(cubeBagConfiguration).GetValidGameIdSum(lines);

        Console.WriteLine(sum);
    }
}

public class ElfGameMinimumCubesSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        var sum = new ElfCubeGameMinimumCubesCalculator().GetMinimumCubesProductsSum(lines);

        Console.WriteLine(sum);
    }
}