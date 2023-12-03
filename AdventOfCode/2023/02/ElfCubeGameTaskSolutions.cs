namespace AdventOfCode;

public class ElfGameValidIdSumSolution : ITaskSolution
{
    public void Run()
    {
        var lines = File.ReadAllLines(Path.Combine("2023", "02", "input02.txt"));
        
        var cubeBagConfiguration = new Dictionary<string, int>
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 },
        };

        var sum = new ElfCubeGameValidSum(cubeBagConfiguration).GetValidGameIdSum(lines);

        Console.WriteLine(sum);
    }
}

public class ElfGameMinimumCubesSolution : ITaskSolution
{
    public void Run()
    {
        var lines = File.ReadAllLines(Path.Combine("2023", "02", "input02.txt"));

        var sum = new ElfCubeGameMinimumCubesCalculator().GetMinimumCubesProductsSum(lines);

        Console.WriteLine(sum);
    }
}