public class Directory
{
    public string Name { get; }
    public string ParentName { get; }
    public int MemorySize { get; set; }

    public Directory(string name, string parentName)
    {
        this.ParentName = parentName;
        Name = name;
    }
}