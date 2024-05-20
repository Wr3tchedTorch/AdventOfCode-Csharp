using System.Text.RegularExpressions;

public class FileSystem
{
    Dictionary<string, Directory> directories = [];
    private string input;
    public FileSystem(string filePath)
    {
        input = new StreamReader(filePath).ReadToEnd();
        input = Regex.Replace(input, @"\$\s\w{2}\s\.\.", "");
        input = input.Replace("\r", "");
        SetDirectories();
    }

    public void SetDirectories()
    {
        // Regex to get CD commands: (?<=\$\scd\s)\w{1}
        // Regex to remove commands after reading: \$.+
        string currentDirectory = "";

        if (directories.Count == 0) currentDirectory = "/";
        currentDirectory = Regex.Match(input, @"(?<=\$\scd\s)\w{1}").Value;

        Regex replaceCommands = new Regex(@"\$.+\n");
        input = replaceCommands.Replace(input, "", 2);

        string[] dirContents = Regex.Replace(input.Substring(0, input.IndexOf("$")), @"\n$", "").Split("\n");
        System.Console.WriteLine(dirContents);
    }

    public int GetSumOfDeletableFiles()
    {
        throw new NotImplementedException();
    }
}
