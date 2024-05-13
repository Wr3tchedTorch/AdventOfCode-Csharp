namespace SectionAssignmentsTest;

using FluentAssertions;
using SectionAssignments;

public class SectionAssignmentsTest
{
    string basePath = Path.GetFullPath("./").Replace("bin/Debug/net8.0/", "");

    [Fact]
    public void TestExampleInputFullyOverlaping() => new SectionAssignments($"{basePath}files/exampleInput.txt").GetOverlappingPairsCount(true).Should().Be(2);
    [Fact]
    public void TestPuzzleInputFullyOverlaping() => new SectionAssignments($"{basePath}files/puzzleInput.txt").GetOverlappingPairsCount(true).Should().Be(471);
    [Fact]
    public void TestExampleInputOverlaping() => new SectionAssignments($"{basePath}files/exampleInput.txt").GetOverlappingPairsCount().Should().Be(4);
    [Fact]
    public void TestPuzzleInputOverlaping() => new SectionAssignments($"{basePath}files/puzzleInput.txt").GetOverlappingPairsCount().Should().Be(888);
}