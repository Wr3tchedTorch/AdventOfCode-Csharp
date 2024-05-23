using System.Text.RegularExpressions;

public class FileSystem
{
    private string input;
    public FileSystem(string filePath)
    {
        input = new StreamReader(filePath).ReadToEnd();
    }

    public int GetSumOfDeletableFiles() {
        throw new NotImplementedException();
    }
}
