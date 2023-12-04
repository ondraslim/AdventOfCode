namespace AdventOfCode.Year2023.Day04;

public class ScratchCardScoreSolution : ITaskSolution
{
    public void Run()
    {
        var cards = InputData.Data.Split(Environment.NewLine);

        Console.WriteLine(new ScratchcardCalculator().CalculateScore(cards));
        Console.WriteLine(new ScratchcardCalculator().CalculateCopyCount(cards));
    }
}
