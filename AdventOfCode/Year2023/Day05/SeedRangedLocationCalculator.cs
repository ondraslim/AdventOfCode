using AdventOfCode.Helpers;

namespace AdventOfCode.Year2023.Day05;

public class SeedRangedLocationCalculator
{
    public long GetSeedsRangedWithClosestLocation(string[] lines)
    {
        var seeds = GetSeeds(lines[0]);
        var seedsRanged = GetSeedRanges(seeds);

        return GetSeedWithClosestLocation(lines, seedsRanged);
    }

    private static IEnumerable<(long Start, long End)> GetSeedRanges(IEnumerable<long> seeds)
    {
        return seeds.Chunk(2).Select(pair => (pair[0], pair[0] + pair[1] - 1));
    }

    private static long GetSeedWithClosestLocation(string[] lines, IEnumerable<(long Start, long End)> seedRanges)
    {
        var maps = GetMaps(lines[2..]);

        return seedRanges.Aggregate(long.MaxValue, (currentClosest, seedRange) =>
        {
            var location = GetFinalSeedLocation(seedRange, maps).Start;
            return location < currentClosest ? location : currentClosest;
        });
    }

    private static (long Start, long Length) GetFinalSeedLocation((long Start, long End) seedRange, IEnumerable<SeedMap> maps)
    {
        return maps.Aggregate(seedRange, GetNextDestination);
    }

    private static (long Start, long Length) GetNextDestination((long Start, long End) seedRange, SeedMap map)
    {
        foreach (var configuration in map.Configurations)
        {
            var configurationSourceEnd = configuration.Source + configuration.Range;
            var overlapStart = Math.Max(seedRange.Start, configuration.Source);
            var overlapEnd = Math.Min(seedRange.End, configurationSourceEnd);
            if (overlapStart <= overlapEnd)
            {
                var offset = overlapStart - configuration.Source;
                var remainingLength = overlapEnd - overlapStart;
                var newStart = configuration.Destination + offset;
                var newRange = (newStart, newStart + remainingLength);
                return newRange;
            }
        }

        return seedRange;
    }

    private static IList<SeedMap> GetMaps(IEnumerable<string> lines)
    {
        var maps = new List<SeedMap>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (!char.IsDigit(line[0]))
            {
                maps.Add(new SeedMap(new List<(long Destination, long Source, long Range)>()));
            }
            else
            {
                var configuration = GetConfiguration(line);
                maps.Last().Configurations.Add(configuration);
            }
        }

        return maps;
    }

    private static IEnumerable<long> GetSeeds(string line)
    {
        var seedNumberStartIndex = line.IndexOf(':') + 1;
        var seedNumberData = line.AsSpan()[seedNumberStartIndex..];

        return GetNumbers(seedNumberData);
    }

    private static (long Destination, long Source, long Range) GetConfiguration(string line)
    {
        var numbers = GetNumbers(line);
        return (numbers[0], numbers[1], numbers[2]);
    }

    private static IList<long> GetNumbers(ReadOnlySpan<char> text)
    {
        var numbers = new List<long>();
        foreach (var number in text.SplitFast(" "))
        {
            if (!number.IsWhiteSpace())
            {
                numbers.Add(long.Parse(number));
            }
        }

        return numbers;
    }

    private record struct SeedMap(
        IList<(long Destination, long Source, long Range)> Configurations);
}