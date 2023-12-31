﻿using AdventOfCode.Year2023.Day01;
using FluentAssertions;
using Xunit;

namespace AdventOfCode.Tests.Year2023.Day01;

public class PartOneTests
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
        var sut = new PartOne();

        var calibrationValue = sut.Run(input);
        
        calibrationValue.Should().Be(expectedValue);
    }

    [Fact]
    public void SumDecoded()
    {
        var sut = new PartOne();
        var input = new[] { "12", "1abc2", "2fds6dsa" };

        var calibrationValuesSum = sut.Run(input);

        calibrationValuesSum.Should().Be(50);
    }
}