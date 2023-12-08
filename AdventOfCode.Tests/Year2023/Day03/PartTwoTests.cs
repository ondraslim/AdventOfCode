using AdventOfCode.Year2023.Day03;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day03;

public class PartTwoTests
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
        var sut = new PartTwo();

        var ratio = sut.Run(new[] { schemaLine });

        ratio.Should().Be(expectedRatio);
    }

    [Theory]
    [ClassData(typeof(PartTwoTestData))]
    public void EngineSchemaDifferentLineGearRatioTests(string[] schema, int expectedRatio)
    {
        var sut = new PartTwo();

        var ratio = sut.Run(schema);

        ratio.Should().Be(expectedRatio);
    }
}