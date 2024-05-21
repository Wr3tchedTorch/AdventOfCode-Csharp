using System.Text.RegularExpressions;

public class FileSystem
{
    Dictionary<string, Directory> directories = [];
    private string input;
    public FileSystem(string filePath)
    {
        input = new StreamReader(filePath).ReadToEnd();
        input = Regex.Replace(input.Replace("\r", ""), @"\$\s\w{2}\s\.\.\n", "");
        
        SetDirectories();
    }

    public void SetDirectories()
    {
        while (input.Length > 0)
        {
            string currentDirectory = "";

            if (directories.Count == 0) currentDirectory = "/";
            else currentDirectory = Regex.Match(input, @"(?<=\$\scd\s)\w{1}").Value;

            string parentDir = "";
            if (directories.ContainsKey(currentDirectory)) parentDir = directories[currentDirectory].ParentName;

            Directory newDir = new Directory(currentDirectory, parentDir, directories);

            Regex replaceCommands = new Regex(@"\$.+\n");
            input = replaceCommands.Replace(input, "", 2);

            int endOfLine = input.IndexOf("$") == -1 ? input.Length : input.IndexOf("$");
            string[] dirContents = Regex.Replace(input.Substring(0, endOfLine), @"\n$", "").Split("\n");
            input = input.Substring(endOfLine);
            foreach (string line in dirContents)
            {
                if (Regex.Match(line, @"\d+").Success)
                {
                    int memory = int.Parse(Regex.Match(line, @"\d+").Value);
                    newDir.MemorySize += memory;
                    UpdateParentMemorySize(newDir.ParentName, memory);
                    continue;
                }

                Directory childDir = new Directory(Regex.Match(line, @"(?<=dir\s)\w+").Value, currentDirectory, directories);
                directories.Add(childDir.Name, childDir);
            }
            directories[currentDirectory] = newDir;
        }
    }

    public void UpdateParentMemorySize(string parentName, int size)
    {
        if (string.IsNullOrEmpty(parentName)) return;
        directories[parentName].MemorySize += size;

        UpdateParentMemorySize(directories[parentName].ParentName, size);
    }

    public int GetSumOfDeletableFiles()
    {
        throw new NotImplementedException();
    }
}
