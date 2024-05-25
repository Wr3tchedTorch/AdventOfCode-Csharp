namespace TreeHouseTest;

using FluentAssertions;
using TreeHouse;

public class TreeHouseTest
{
    private readonly string BasePath = Path.GetFullPath("./").Replace(@"\bin\Debug\net8.0", "");
    [Fact]
    public void TestExampleSample() => new TreeHouse($"{BasePath}/files/exampleSample.txt").GetNumberOfVisibleTrees().Should().Be(21);
}
