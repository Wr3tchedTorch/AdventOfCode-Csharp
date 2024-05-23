using System.Text.RegularExpressions;

public class FileSystem
{
    private Dictionary<string, int> directories = [];
    string input;
    public FileSystem(string filePath)
    {
        input = new StreamReader(filePath).ReadToEnd();
        input = input.Replace("\r", "");
        SetDirectories();
    }

    private void AddDirectory(string path)
    {
        if (!directories.ContainsKey(path)) directories.Add(path, 0);
    }

    private void SetDirectories()
    {
        Stack<string> stack = [];
        string currentPath = "";

        foreach (string line in input.Split("\n"))
        {
            if (line == "$ ls" || line.Split()[0] == "dir") continue;

            if (char.IsDigit(line.ToCharArray()[0]))
            {
                UpdateStackSize(stack, int.Parse(line.Split()[0]));
                continue;
            }

            currentPath = RunCommand(line, stack, currentPath);
        }
    }

    private void UpdateStackSize(Stack<string> stack, int size)
    {
        foreach (string path in stack)
        {
            directories[path] += size;
        }
    }

    private string RunCommand(string command, Stack<string> stack, string currentPath)
    {
        if (command.Equals("$ cd .."))
        {
            stack.Pop();
            return Regex.Replace(currentPath, @"\/(\w|\d)+$", "");
        }

        if (command.Equals("$ cd /"))
        {
            stack.Clear();
            stack.Push("/");
            AddDirectory("/");
            return "/";
        }

        string newPath = Regex.Match(command, @"(?<=\$\scd\s).+").Value;
        currentPath = currentPath == "/" ? $"/{newPath}" : $"{currentPath}/{newPath}";
        stack.Push(currentPath);
        
        AddDirectory(currentPath);        
        return currentPath;
    }

    public int GetSumOfDeletableFiles()
    {
        int total = 0;
        foreach (int size in directories.Values)
        {
            if (size < 100000) total += size;
        }
        return total;
    }
}
