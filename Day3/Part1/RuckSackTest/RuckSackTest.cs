using Domain;
using FluentAssertions;

namespace RuckSackTest;

public class UnitTest1
{
    string baseUrl = Path.GetFullPath("./").Replace("\\bin\\Debug\\net8.0\\", "");

    [Fact]
    public void TestExampleInput() => new RuckSack($"{baseUrl}\\files\\exampleInput.txt").PrioritySum().Should().Be(157);
    [Fact]
    public void TestPuzzleInput() => new RuckSack($"{baseUrl}\\files\\puzzleInput.txt").PrioritySum().Should().Be(8202);
}