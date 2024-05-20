public class Directory
{
    public string Name { get; }
    private string parentName;
    private Dictionary<string, Directory> directories = [];
    public int MemorySize
    {
        get { return MemorySize; }
        set
        {
            if (!string.IsNullOrEmpty(parentName)) {
                directories[parentName].MemorySize += value;
            }
            MemorySize += value;
        }
    }

    public Directory(string name, string parentName, Dictionary<string, Directory> directories)
    {
        this.parentName  = parentName;
        this.directories = directories;
        
        Name = name;
    }
}