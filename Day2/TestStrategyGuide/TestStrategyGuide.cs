namespace TestStrategyGuide;
using FluentAssertions;
using StrategyGuide;

public class TestStrategyGuide
{
    [Fact]
    public void TestExampleInput()
    {
        StrategyGuide guideSheet = new StrategyGuide("./files/exampleInput.txt");
        guideSheet.GetTotalScore().Should().Be(15);
    }
}