using Domain;
using FluentAssertions;

namespace RuckSackTest;

public class UnitTest1
{
    string baseUrl = Path.GetFullPath("./").Replace("\\bin\\Debug\\net8.0\\", "");

    [Fact]
    public void TestExampleInput() => new RuckSack($"{baseUrl}\\files\\exampleInput.txt").GetPrioritySum().Should().Be(157);
    [Fact]
    public void TestPuzzleInput() => new RuckSack($"{baseUrl}\\files\\puzzleInput.txt").GetPrioritySum().Should().Be(8202);

    [Fact]
    public void TestExampleInputGroupPriority() => new RuckSack($"{baseUrl}\\files\\exampleInput.txt").GetGroupsPrioritySum().Should().Be(70);    
    [Fact]
    public void TestPuzzleInputGroupPriority() => new RuckSack($"{baseUrl}\\files\\puzzleInput.txt").GetGroupsPrioritySum().Should().Be(2864);
}