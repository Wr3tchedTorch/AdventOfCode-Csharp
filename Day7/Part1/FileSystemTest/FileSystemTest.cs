using FluentAssertions;
namespace FileSystemTest;

public class FileSystemTest
{
    string basePath = Path.GetFullPath("./").Replace(@"/bin/Debug/net8.0/", "");

    [Fact]
    public void TestExampleSample() => new FileSystem($"{basePath}/files/exampleSample.txt").GetSumOfDeletableFiles().Should().Be(95437);

    [Fact]
    public void TestSampleWithDuplicateDirName() => new FileSystem($"{basePath}/files/firstSample.txt").GetSumOfDeletableFiles().Should().Be(95437);

    [Fact]
    public void TestSampleWithTriplicateDirName() => new FileSystem($"{basePath}/files/secondSample.txt").GetSumOfDeletableFiles().Should().Be(96021);

    // Output before solving issue: 
    // 136697 
    // 940304
    // 1450068
    [Fact]
    public void TestPuzzleSample() => new FileSystem($"{basePath}/files/puzzleSample.txt").GetSumOfDeletableFiles().Should().Be(95437);
}