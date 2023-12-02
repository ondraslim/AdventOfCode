using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests;

public class CalibrationValueDecoderTests
{
    private readonly CalibrationValueDecoder _calibrationValueDecoder;

    public CalibrationValueDecoderTests()
    {
        _calibrationValueDecoder = new CalibrationValueDecoder();
    }

    [Theory]
    [InlineData("12", 12)]
    [InlineData("1abc2", 12)]
    [InlineData("1a3c2", 12)]
    [InlineData("1a3c2asd", 12)]
    [InlineData("1", 11)]
    [InlineData("ads3dsda", 33)]
    public void Decode(string input, int expectedValue)
    {
        var calibrationValue = _calibrationValueDecoder.Decode(input);
        
        calibrationValue.Should().Be(expectedValue);
    }

    [Fact]
    public void SumDecoded()
    {
        var input = new[] { "12", "1abc2", "2fds6dsa" };

        var calibrationValuesSum = _calibrationValueDecoder.SumDecoded(input);

        calibrationValuesSum.Should().Be(50);
    }
}