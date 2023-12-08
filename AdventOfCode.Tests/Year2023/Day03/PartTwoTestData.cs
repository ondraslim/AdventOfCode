using System.Collections;

namespace AdventOfCode.Tests.Year2023.Day03;

public class PartTwoTestData : IEnumerable<object[]>
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