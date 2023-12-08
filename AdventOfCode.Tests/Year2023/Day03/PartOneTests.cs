using AdventOfCode.Year2023.Day03;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day03;

public class PartOneTests
{
    [Theory]
    [InlineData("..12...", 0)]
    [InlineData("1#...", 1)]
    [InlineData("..1#", 1)]
    [InlineData("..#1", 1)]
    [InlineData("..#1...", 1)]
    [InlineData("..#12...", 12)]
    [InlineData("..12#...", 12)]
    public void EngineSchemaSameLineAdjacentSymbolTests(string schemaLine, int expectedNumber)
    {
        var sut = new PartOne();

        var engineParts = sut.Run(new []{ schemaLine });

        engineParts.Should().Be(expectedNumber);
    }

    [Theory]
    [ClassData(typeof(PartTwoTestData))]
    public void EngineSchemaDifferentLineAdjacentSymbolTests(string[] schema, int expectedNumber)
    {
        var enginePartsDecoder = new PartOne();

        var engineParts = enginePartsDecoder.Run(schema);

        engineParts.Should().Be(expectedNumber);
    }
}