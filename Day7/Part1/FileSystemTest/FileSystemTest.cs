using FluentAssertions;
namespace FileSystemTest;

public class FileSystemTest
{
    string basePath = Path.GetFullPath("./").Replace(@"\bin\Debug\net8.0\", "");

    [Fact]
    public void TestExampleSample() => new FileSystem($"{basePath}/files/exampleSample.txt").GetSumOfDeletableFiles().Should().Be(95437);
}