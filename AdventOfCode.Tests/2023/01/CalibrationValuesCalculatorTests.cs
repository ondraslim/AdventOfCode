using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests;

public class CalibrationValuesCalculatorTests
{
    private readonly CalibrationValuesCalculator _calibrationValuesCalculator;

    public CalibrationValuesCalculatorTests()
    {
        _calibrationValuesCalculator = new CalibrationValuesCalculator();
    }

    [Theory]
    [InlineData("12", 12)]
    [InlineData("1abc2", 12)]
    [InlineData("1a3c2", 12)]
    [InlineData("1a3c2asd", 12)]
    [InlineData("1", 11)]
    [InlineData("ads3dsda", 33)]
    public void GetCalibrationValueTests(string input, int expectedValue)
    {
        var calibrationValue = _calibrationValuesCalculator.GetCalibrationValue(input);
        
        calibrationValue.Should().Be(expectedValue);
    }

    [Fact]
    public void GetCalibrationValueSumTest()
    {
        var input = new[] { "12", "1abc2", "2fds6dsa" };

        var calibrationValuesSum = _calibrationValuesCalculator.GetCalibrationValuesSum(input);

        calibrationValuesSum.Should().Be(50);
    }
}