using AdventOfCode.Helpers;

namespace AdventOfCode.Year2023.Day05;

public class PartOne
{
    public long Run(string[] lines)
    {
        var seeds = GetSeeds(lines[0]);
        return GetSeedWithClosestLocation(lines, seeds);
    }

    private static long GetSeedWithClosestLocation(string[] lines, IEnumerable<long> seeds)
    {
        var maps = GetMaps(lines[2..]);

        return seeds.Aggregate(long.MaxValue, (currentClosest, seed) =>
        {
            var seedLocation = GetFinalSeedLocation(seed, maps);
             return seedLocation < currentClosest ? seedLocation : currentClosest;
        });
    }

    private static long GetFinalSeedLocation(long seed, IEnumerable<SeedMap> maps)
    {
        return maps.Aggregate(seed, GetNextDestination);
    }

    private static long GetNextDestination(long seed, SeedMap map)
    {
        foreach (var configuration in map.Configurations)
        {
            if (configuration.Source <= seed && seed < configuration.Source + configuration.Range)
            {
                var offset = seed - configuration.Source;
                return configuration.Destination + offset;
            }
        }

        return seed;
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
