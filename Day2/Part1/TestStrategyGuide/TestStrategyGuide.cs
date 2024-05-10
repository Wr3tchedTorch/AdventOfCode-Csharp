namespace TestStrategyGuide;
using FluentAssertions;
using StrategyGuide;

public class TestStrategyGuide
{
    [Fact]
    public void TestExampleInput() => new StrategyGuide("../../../files/exampleInput.txt").GetTotalScore().Should().Be(15);
    [Fact]
    public void TestPuzzleInput() => new StrategyGuide("../../../files/puzzleInput.txt").GetTotalScore().Should().Be(13268);
}