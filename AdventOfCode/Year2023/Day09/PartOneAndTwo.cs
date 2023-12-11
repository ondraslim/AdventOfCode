using AdventOfCode.Helpers;

namespace AdventOfCode.Year2023.Day09;

public class PartOneAndTwo
{
    public long PartOne(string[] lines)
    {
       var histories = GetHistories(lines);

       return histories.Sum(ExtrapolateEnd);
    }

    public long PartTwo(string[] lines)
    {
        var histories = GetHistories(lines);

        return histories.Sum(ExtrapolateBeginning);
    }

    private static long ExtrapolateEnd(List<long> history)
    {
        var sequences = GetSequences(history);
        long extrapolated = 0;

        for (var i = sequences.Count - 1; i >= 0; i--)
        {
            var current = sequences[i];
            extrapolated += current.Last();
        }

        return extrapolated;
    }

    private static long ExtrapolateBeginning(List<long> history)
    {
        var sequences = GetSequences(history);
        long extrapolated = 0;

        for (var i = sequences.Count - 1; i >= 0; i--)
        {
            var current = sequences[i];
            extrapolated = current.First() - extrapolated;
        }

        return extrapolated;
    }

    private static List<List<long>> GetSequences(List<long> history)
    {
        var sequences = new List<List<long>> { history };

        do
        {
            var lastSequence = sequences.Last();
            var newSequence = new List<long>();

            for (var i = 0; i < lastSequence.Count - 1; i++)
            {
                newSequence.Add(lastSequence[i + 1] - lastSequence[i]);
            }

            sequences.Add(newSequence);
        } while (!sequences.Last().All(n => n is 0));

        return sequences;
    }

    private static List<List<long>> GetHistories(string[] lines)
    {
        var histories = new List<List<long>>();

        foreach (var line in lines)
        {
            var history = new List<long>();
            foreach (var num in line.AsSpan().SplitFast(" "))
            {
                history.Add(long.Parse(num));
            }
            histories.Add(history);
        }

        return histories;
    }
}