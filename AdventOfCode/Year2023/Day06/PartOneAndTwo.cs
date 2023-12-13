namespace AdventOfCode.Year2023.Day06;

public class PartOneAndTwo
{
    public long PartOne(string[] lines)
    {
        var times = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();
        var distances = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToArray();

        long result = 1;
        for (var i = 0; i < times.Length; i++)
        {
            var count = CalculateNewRecordCombinationCountSmart(times[i], distances[i]);
            result *= count;
        }

        return result;
    }

    public long PartTwo(string[] lines)
    {
        var time = long.Parse(string.Join("", lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1)));
        var distance = long.Parse(string.Join("", lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1)));

        return CalculateNewRecordCombinationCountSmart(time, distance);
    }

    private static long CalculateNewRecordCombinationCount(long time, long recordDistance)
    {
        var count = 0;
        for (var accelerateTime = 1; accelerateTime < time - 1; accelerateTime++)
        {
            var distance = accelerateTime * (time - accelerateTime);
            if (distance > recordDistance)
            {
                count++;
            }
        }

        return count;
    }

    private static long CalculateNewRecordCombinationCountSmart(long time, long recordDistance)
    {
        var lowerBound = (time - Math.Sqrt(Math.Pow(time, 2) - 4 * recordDistance)) / 2;
        var upperBound = (time + Math.Sqrt(Math.Pow(time, 2) - 4 * recordDistance)) / 2;

        return (long) Math.Ceiling(upperBound) - (long) Math.Floor(lowerBound) - 1;
    }
}