using AdventOfCode.Helpers;

namespace AdventOfCode.Year2023.Day08;

public class PartOneAndTwo
{
    public long PartOne(string[] lines)
    {
        var moveInstructions = lines[0];

        var map = GetMap(lines[2..]);
        
        return CalculateSteps(
            moveInstructions,
            "AAA", 
            map, 
            p => p == "ZZZ");
    }


    public long PartTwo(string[] lines)
    {
        var moveInstructions = lines[0];
        var map = GetMap(lines[2..]);

        var startPositions = map.Keys.Where(k => k.EndsWith('A'));

        var steps = startPositions.Select(s => CalculateSteps(moveInstructions, s, map, p => p.EndsWith('Z')));
        return MathUtils.Lcm(steps);
    }

    private static long CalculateSteps(
        string moveInstructions, 
        string currentPosition, 
        IReadOnlyDictionary<string, (string Left, string Right)> map,
        Func<string, bool> stopFunction)
    {
        var moveCount = 0;
        while (true)
        {
            foreach (var move in moveInstructions)
            {
                moveCount++;

                currentPosition = move == 'L' 
                    ? map[currentPosition].Left 
                    : map[currentPosition].Right;

                if (stopFunction.Invoke(currentPosition))
                {
                    return moveCount;
                }
            }
        }
    }

    private static Dictionary<string, (string Left, string Right)> GetMap(IEnumerable<string> lines)
    {
        var map = new Dictionary<string, (string Left, string Right)>();

        foreach (var line in lines)
        {
            var split = line.IndexOf('=');
            var key = line[..split].Trim();

            split++;
            var values = line[split..].Split(", ");
            var left = values[0][2..];
            var right = values[1][..^1];

            map[key] = (left, right);
        }

        return map;
    }

}