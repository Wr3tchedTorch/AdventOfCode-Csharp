namespace SectionAssignmentsTest;

using FluentAssertions;
using SectionAssignments;

public class UnitTest1
{
    string basePath = Path.GetFullPath("./").Replace("\\bin\\Debug\\net8.0", "");

    [Fact]
    public void TestExampleInput() => new SectionAssignments($"{basePath}files\\exampleInput.txt").GetOverlappingPairsCount().Should().Be(2);
    [Fact]
    public void TestPuzzleInput() => new SectionAssignments($"{basePath}files\\puzzleInput.txt").GetOverlappingPairsCount().Should().Be(471);
}