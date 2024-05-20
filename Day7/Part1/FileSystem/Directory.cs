using System.Collections;

public class Directory {
    public int TotalSize { get; set; } = 0;
    public int Size { get; set; } = 0;
    public ArrayList<Directory> chidren = [];
}