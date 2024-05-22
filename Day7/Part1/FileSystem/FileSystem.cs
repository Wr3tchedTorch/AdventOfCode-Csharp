using System.Text.RegularExpressions;

public class FileSystem
{
    Dictionary<string, Directory> directories = [];
    private string input;
    private int id;
    public FileSystem(string filePath)
    {
        input = new StreamReader(filePath).ReadToEnd();
        input = Regex.Replace(input.Replace("\r", ""), @"\$\s\w{2}\s\.\.\n", "");

        SetDirectories();
    }

    public void SetDirectories()
    {
        if (input.Length <= 0) return;

        string currentDirectory = ParseNextDirectory();
        string parentDir = GetParentDirectory(currentDirectory);

        Regex replaceCommands = new Regex(@"\$.+\n");
        input = replaceCommands.Replace(input, "", 2);

        string[] dirContents = GetDirectoryContents();
        directories[currentDirectory] = ParseDirectoryContent(dirContents, new Directory(currentDirectory, parentDir));

        SetDirectories();
    }

    private Directory ParseDirectoryContent(string[] dirContents, Directory dir)
    {
        foreach (string line in dirContents)
        {
            if (Regex.Match(line, @"\d+").Success)
            {
                long memory = long.Parse(Regex.Match(line, @"\d+").Value);
                dir.MemorySize += memory;
                UpdateParentMemorySize(dir.ParentName, memory);
                continue;
            }

            Directory childDir = new Directory(Regex.Match(line, @"(?<=dir\s)\w+").Value, dir.Name);
            if (directories.ContainsKey(childDir.Name))
            {
                childDir.Name = $"{childDir.Name}{id++}";
                Regex renameDir = new Regex(@"(?<=cd|dir)\s.+\s");
                input = renameDir.Replace(input, $" {childDir.Name}\n", 1);
            }

            directories.Add(childDir.Name, childDir);
        }

        return dir;
    }

    private string ParseNextDirectory()
    {
        if (directories.Count == 0) return "/";

        return Regex.Match(input, @"(?<=\$\scd\s)\w{1}.*").Value;
    }

    private string GetParentDirectory(string dir)
    {
        if (directories.ContainsKey(dir)) return directories[dir].ParentName;

        return "";
    }

    private string[] GetDirectoryContents()
    {
        int endOfLine = input.IndexOf("$") == -1 ? input.Length : input.IndexOf("$");
        string[] dirContents = Regex.Replace(input.Substring(0, endOfLine), @"\n$", "").Split("\n");
        input = input.Substring(endOfLine);
        return dirContents;
    }

    public void UpdateParentMemorySize(string parentName, long size)
    {
        if (string.IsNullOrEmpty(parentName)) return;
        directories[parentName].MemorySize += size;

        UpdateParentMemorySize(directories[parentName].ParentName, size);
    }

    public long GetSumOfDeletableFiles()
    {
        long total = 0;
        foreach (Directory dir in directories.Values)
        {
            if (dir.MemorySize <= 100000) total += dir.MemorySize;
        }
        return total;
    }
}
