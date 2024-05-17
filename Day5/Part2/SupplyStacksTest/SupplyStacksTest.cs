namespace SupplyStacksTest;
using SupplyStacks;
using FluentAssertions;

public class SupplyStacksTest
{
    string basePath = Path.GetFullPath("./").ToString().Replace("\\", "/").Replace("/bin/Debug/net8.0/", "");

    [Fact]
    public void TestExampleInput() => new SupplyStacks($"{basePath}/files/exampleInput.txt").GetTopCrates().Should().Be("MCD");
    
    [Fact]
    public void TestPuzzleInput() => new SupplyStacks($"{basePath}/files/puzzleInput.txt").GetTopCrates().Should().Be("NBTVTJNFJ");
}