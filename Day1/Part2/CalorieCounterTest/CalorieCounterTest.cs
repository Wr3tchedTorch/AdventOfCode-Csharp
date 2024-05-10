namespace CalorieCounterTest;
using Domain;
using FluentAssertions;

public class CalorieCounterTest
{
    [Fact]
    public void TestExampleInput() => new CalorieCounter("../../../files/exampleInput.txt").GetHighestCalorieCount().Should().Be(24000);

    [Fact]
    public void TestExampleInputTopTree() => new CalorieCounter("../../../files/exampleInput.txt").GetTopTreeCalorieCount().Should().Be(45000);

    [Fact]
    public void TestPuzzleInput() => new CalorieCounter("../../../files/puzzleInput.txt").GetHighestCalorieCount().Should().Be(66719);
    [Fact]
    public void TestPuzzleInputTopTree() => new CalorieCounter("../../../files/puzzleInput.txt").GetTopTreeCalorieCount().Should().Be(198551);
}