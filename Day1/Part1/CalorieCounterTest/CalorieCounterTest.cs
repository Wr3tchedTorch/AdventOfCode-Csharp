namespace CalorieCounterTest;
using Domain;
using FluentAssertions;

public class CalorieCounterTest
{
    [Fact]
    public void TestExampleInput() => new CalorieCounter("../../../files/exampleInput.txt").GetHighestCalorieCount().Should().Be(24000);

    [Fact]
    public void TestPuzzleInput() => new CalorieCounter("../../../files/puzzleInput.txt").GetHighestCalorieCount().Should().Be(66719);
}