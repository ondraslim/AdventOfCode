namespace AdventOfCode.Year2023.Day04;

public class ScratchCardScoreSolution : ITaskSolution
{
    public void Run()
    {
        var cards = InputData.Data.Split(Environment.NewLine);

        var scratchCardCalculator = new ScratchcardCalculator();

        Console.WriteLine(scratchCardCalculator.CalculateScore(cards));
        Console.WriteLine(scratchCardCalculator.CalculateCopyCount(cards));
    }
}
