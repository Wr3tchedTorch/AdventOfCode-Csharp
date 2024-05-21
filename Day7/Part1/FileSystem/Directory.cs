public class Directory
{
    public string Name { get; }
    public string ParentName { get; }
    public int MemorySize { get; set; }

    public Directory(string name, string parentName, Dictionary<string, Directory> directories)
    {
        this.ParentName = parentName;
        Name = name;
    }
}