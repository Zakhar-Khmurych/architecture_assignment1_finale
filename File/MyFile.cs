namespace architecture_assignment1_finale;

public class MyFile 
{
    public string Path { get; }
    public string Name { get; }
    
    public string Content { get; set; }
    
    public User Owner { get; set; }

    public MyFile(string path, string name)
    {
        Path = path;
        Name = name;
        Content = "";
    }
}