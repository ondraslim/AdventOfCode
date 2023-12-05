namespace AdventOfCode.Year2023.Day03;

public class EnginePartsTaskSolutions : ITaskSolution
{
    public void Run()
    {
        var lines = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine(new EnginePartsDecoder().Decode(lines));
        Console.WriteLine(new GearRatioCalculator().Calculate(lines));
    }
}
