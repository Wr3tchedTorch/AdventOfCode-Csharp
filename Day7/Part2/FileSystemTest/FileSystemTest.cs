using FluentAssertions;
namespace FileSystemTest;

public class FileSystemTest
{
    string basePath = Path.GetFullPath("./").Replace(@"\bin\Debug\net8.0\", "");

    [Fact]
    public void TestExampleSample() => new FileSystem($"{basePath}/files/exampleSample.txt").GetSizeOfDeletableDir().Should().Be(24933642);

    [Fact]
    public void TestPuzzleSample() => new FileSystem($"{basePath}/files/puzzleSample.txt").GetSizeOfDeletableDir().Should().Be(8998590);
}