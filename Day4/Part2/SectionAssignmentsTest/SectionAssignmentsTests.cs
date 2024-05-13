namespace SectionAssignmentsTest;

using FluentAssertions;
using SectionAssignments;

public class UnitTest1
{
    string basePath = Path.GetFullPath("./").Replace("\\bin\\Debug\\net8.0", "");

    [Fact]
    public void TestExampleInputFullyOverlaping() => new SectionAssignments($"{basePath}files\\exampleInput.txt").GetFullyOverlappingPairsCount().Should().Be(2);
    [Fact]
    public void TestPuzzleInputFullyOverlaping() => new SectionAssignments($"{basePath}files\\puzzleInput.txt").GetFullyOverlappingPairsCount().Should().Be(471);
    [Fact]
    public void TestExampleInputOverlaping() => new SectionAssignments($"{basePath}files\\exampleInput.txt").GetOverlappingPairsCount().Should().Be(2);
}