using AdventOfCode.Year2023.Day01;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day01;

public class CalibrationValueDecoderTests
{
    [Theory]
    [InlineData("12", 12)]
    [InlineData("1abc2", 12)]
    [InlineData("1a3c2", 12)]
    [InlineData("1a3c2asd", 12)]
    [InlineData("1", 11)]
    [InlineData("ads3dsda", 33)]
    public void Decode(string input, int expectedValue)
    {
        var sut = new CalibrationValueDecoder();

        var calibrationValue = sut.Decode(input);
        
        calibrationValue.Should().Be(expectedValue);
    }

    [Fact]
    public void SumDecoded()
    {
        var sut = new CalibrationValueDecoder();
        var input = new[] { "12", "1abc2", "2fds6dsa" };

        var calibrationValuesSum = sut.SumDecoded(input);

        calibrationValuesSum.Should().Be(50);
    }
}