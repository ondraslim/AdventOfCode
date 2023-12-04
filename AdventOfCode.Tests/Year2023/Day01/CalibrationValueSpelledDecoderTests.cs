using AdventOfCode.Year2023.Day01;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day01;

public class CalibrationValueSpelledDecoderTests
{
    private readonly CalibrationValueSpelledDecoder _calibrationValueSpelledDecoder;

    public CalibrationValueSpelledDecoderTests()
    {
        _calibrationValueSpelledDecoder = new CalibrationValueSpelledDecoder();
    }

    [Theory]
    [InlineData("12", 12)]
    [InlineData("1abc2", 12)]
    [InlineData("1a3c2", 12)]
    [InlineData("1a3c2asd", 12)]
    [InlineData("1", 11)]
    [InlineData("ads3dsda", 33)]
    public void DecodeTests(string input, int expectedValue)
    {
        var calibrationValue = _calibrationValueSpelledDecoder.Decode(input);

        calibrationValue.Should().Be(expectedValue);
    }

    [Fact]
    public void GetCalibrationValueSumWithDigitsTest()
    {
        var input = new[] { "12", "1abc2", "2fds6dsa" };

        var calibrationValuesSum = _calibrationValueSpelledDecoder.SumDecoded(input);

        calibrationValuesSum.Should().Be(50);
    }

    [Theory]
    [InlineData("one", 11)]
    [InlineData("two", 22)]
    [InlineData("onetw0", 10)]
    [InlineData("onetw", 11)]
    [InlineData("threefour", 34)]
    [InlineData("fiveasdsix", 56)]
    [InlineData("asdfsevenfdsaeightfsda", 78)]
    [InlineData("1fdsninedas", 19)]
    public void GetCalibrationValueWithSpelledNumbersTests(string input, int expectedValue)
    {
        var calibrationValue = _calibrationValueSpelledDecoder.Decode(input);

        calibrationValue.Should().Be(expectedValue);
    }

    [Fact]
    public void GetCalibrationValueSumWithSpelledNumbersTest()
    {
        var input = new[] { "12", "1abc2", "2fds6dsa" };

        var calibrationValuesSum = _calibrationValueSpelledDecoder.SumDecoded(input);

        calibrationValuesSum.Should().Be(50);
    }
}