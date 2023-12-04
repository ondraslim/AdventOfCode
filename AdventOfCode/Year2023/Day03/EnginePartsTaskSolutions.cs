namespace AdventOfCode.Year2023.Day03;

public class EnginePartsNumberSumSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        var sum = new EnginePartsDecoder().Decode(lines);

        Console.WriteLine(sum);
    }
}

public class EngineGearRatioSolution : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        var sum = new GearRatioCalculator().Calculate(lines);

        Console.WriteLine(sum);
    }
}