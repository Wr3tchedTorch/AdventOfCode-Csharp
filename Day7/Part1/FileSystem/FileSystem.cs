public class FileSystem
{
    Dictionary<String, string[]> directoriesMap = [];
    HashSet<int> directoriesSizes = [];

    public FileSystem(string filePath) {
        string input = new StreamReader(filePath).ReadToEnd();
        System.Console.WriteLine(input);
    }

    public int GetSumOfDeletableFiles() {
        throw new NotImplementedException();
    }
}
