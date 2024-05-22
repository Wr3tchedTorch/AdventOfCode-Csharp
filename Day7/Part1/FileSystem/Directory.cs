public class Directory
{
    public string Name { get; }
    public string ParentName { get; }
    public long MemorySize { get; set; }

    public Directory(string name, string parentName)
    {
        ParentName = parentName;
        Name = name;
    }
}