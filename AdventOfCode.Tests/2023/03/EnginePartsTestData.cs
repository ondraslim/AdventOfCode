using System.Collections;

namespace AdventOfCode.Tests;

public class GearRatioTestData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new[]
            {
                
                "3...",
                "*3...",
            },
            9
        };

        yield return new object[]
        {
            new[]
            {
                
                "3...",
                "*...",
                "3...",
            },
            9
        };

        yield return new object[]
        {
            new[]
            {
                
                ".3...",
                "*...",
                "3...",
            },
            9
        };

        yield return new object[]
        {
            new[]
            {
                
                ".33...",
                "*...",
                "3...",
            },
            99
        };

        yield return new object[]
        {
            new[]
            {

                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598..",
            },
            467835
        };
    }
}

public class EnginePartsTestData : IEnumerable<object[]>
{
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new[]
            {
                "#.....",
                "1.....",
            },
            1
        };

        yield return new object[]
        {
            new[]
            {
                ".#.....",
                "1.....",
            },
            1
        };

        yield return new object[]
        {
            new[]
            {
                "..#.....",
                "1.....",
            },
            0
        };
        yield return new object[]
        {
            new[]
            {
                "#.....",
                "1.....",
            },
            1
        };

        yield return new object[]
        {
            new[]
            {
                ".#.....",
                "1.....",
            },
            1
        };

        yield return new object[]
        {
            new[]
            {
                "..#.....",
                "1......",
            },
            0
        };

        yield return new object[]
        {
            new[]
            {
                "1......",
                "..#.....",
            },
            0
        };

        yield return new object[]
        {
            new[]
            {
                "1......",
                ".#.....",
            },
            1
        };

        yield return new object[]
        {
            new[]
            {
                "1......",
                "#.....",
            },
            1
        };

        yield return new object[]
        {
            new[]
            {
                ".1......",
                "#......",
            },
            1
        };

        yield return new object[]
        {
            new[]
            {
                ".12......",
                "#......",
            },
            12
        };

        yield return new object[]
        {
            new[]
            {
                "12......",
                "#.....",
            },
            12
        };

        yield return new object[]
        {
            new[]
            {
                ".12......",
                "#......",
            },
            12
        };

        yield return new object[]
        {
            new[]
            {
                ".12......",
                "#......",
            },
            12
        };

        yield return new object[]
        {
            new[]
            {
                "12......",
                "..#......",
            },
            12
        };
    }
}