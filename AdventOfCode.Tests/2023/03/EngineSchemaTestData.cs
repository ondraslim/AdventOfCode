using System.Collections;

namespace AdventOfCode.Tests;

public class EngineSchemaTestData : IEnumerable<object[]>
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