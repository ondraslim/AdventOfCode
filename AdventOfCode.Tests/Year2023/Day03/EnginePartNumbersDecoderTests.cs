using AdventOfCode.Year2023.Day03;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day03;

public class EnginePartNumbersDecoderTests
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
        var sut = new EnginePartsDecoder();

        var engineParts = sut.Decode(new []{ schemaLine });

        engineParts.Should().Be(expectedNumber);
    }

    [Theory]
    [ClassData(typeof(EnginePartsTestData))]
    public void EngineSchemaDifferentLineAdjacentSymbolTests(string[] schema, int expectedNumber)
    {
        var enginePartsDecoder = new EnginePartsDecoder();

        var engineParts = enginePartsDecoder.Decode(schema);

        engineParts.Should().Be(expectedNumber);
    }
}