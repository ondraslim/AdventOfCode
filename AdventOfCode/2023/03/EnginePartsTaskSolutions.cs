namespace AdventOfCode;

public class EnginePartsNumberSumSolution : ITaskSolution
{
    public void Run()
    {
        var lines = File.ReadAllLines(Path.Combine("2023", "03", "input03.txt"));
        
        var sum = new EnginePartsDecoder().Decode(lines);

        Console.WriteLine(sum);
    }
}

public class EngineGearRatioSolution : ITaskSolution
{
    public void Run()
    {
        var lines = File.ReadAllLines(Path.Combine("2023", "03", "input03.txt"));
        
        var sum = new GearRatioCalculator().Calculate(lines);

        Console.WriteLine(sum);
    }
}