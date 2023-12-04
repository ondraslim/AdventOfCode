using AdventOfCode.Year2023.Day03;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day03;

public class GearRatioCalculatorTests
{
    [Theory]
    [InlineData("..12...", 0)]
    [InlineData("..12*...", 0)]
    [InlineData("..3*3...", 9)]
    [InlineData("..3#3...", 0)]
    [InlineData("..30*3...", 90)]
    [InlineData("..3*3*3...", 18)]
    public void EngineSchemaSameLineGearRatioTests(string schemaLine, int expectedRatio)
    {
        var gearRatioCalculator = new GearRatioCalculator();

        var ratio = gearRatioCalculator.Calculate(new[] { schemaLine });

        ratio.Should().Be(expectedRatio);
    }

    [Theory]
    [ClassData(typeof(GearRatioTestData))]
    public void EngineSchemaDifferentLineGearRatioTests(string[] schema, int expectedRatio)
    {
        var gearRatioCalculator = new GearRatioCalculator();

        var ratio = gearRatioCalculator.Calculate(schema);

        ratio.Should().Be(expectedRatio);
    }
}

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
        var enginePartsDecoder = new EnginePartsDecoder();

        var engineParts = enginePartsDecoder.Decode(new []{ schemaLine });

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