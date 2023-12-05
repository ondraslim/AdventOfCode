using System.Diagnostics;
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
            Console.WriteLine($"Seed {seedRange}");
            var location = GetFinalSeedLocation(seedRange, maps);
            Console.WriteLine("----------------------------------------------------");
            return location < currentClosest ? location : currentClosest;
        });
    }

    private static long GetFinalSeedLocation((long Start, long End) seedRange, IEnumerable<SeedMap> maps)
    {
        var seeds = new List<(long Start, long End)> { seedRange };
        var newSeeds  = new List<(long Start, long End)>();
        foreach (var map in maps)
        {
            Console.WriteLine();
            Console.WriteLine($"Seeds {string.Join(",", seeds)}");
            Console.WriteLine($"Proceeding to {map}");
            newSeeds.Clear();
            foreach (var seed in seeds)
            {
                newSeeds.AddRange(GetNextDestination(seed, map));
            }

            seeds.Clear();
            seeds.AddRange(newSeeds);
        }

        return seeds.Min(s => s.Start);
    }

    private static List<(long Start, long End)> GetNextDestination((long Start, long End) seedRange, SeedMap map)
    {
        var result = new List<(long Start, long End)>();

        foreach (var configuration in map.Configurations)
        {
            var overlapStart = Math.Max(seedRange.Start, configuration.Start);
            var overlapEnd = Math.Min(seedRange.End, configuration.End);
            if (overlapStart <= overlapEnd)
            {
                var remainingLength = overlapEnd - overlapStart;
                var destination = seedRange.Start + configuration.Change;
                var newRange = (destination, destination + remainingLength);
                Console.WriteLine($"{seedRange} + {configuration} -> {newRange}");
                result.Add(newRange);
            }
        }

        if (result.Count is 0)
        {
            Console.WriteLine($"No match {seedRange} in {map}");
            result.Add(seedRange);
        }

        return result;
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
                maps.Add(new SeedMap(new List<Configuration>()));
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

    private static Configuration GetConfiguration(string line)
    {
        var numbers = GetNumbers(line);
        return new Configuration(
            numbers[1],
            numbers[1] + numbers[2],
            numbers[0] - numbers[1]);
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

    private readonly record struct SeedMap(
        IList<Configuration> Configurations)
    {
        public override string ToString() 
            => string.Join(", ", Configurations.Select(c => c.ToString()));
    }

    private readonly record struct Configuration(long Start, long End, long Change)
    {
        public override string ToString()
            => $"({Start}, {End} | {Change})";
    }
}