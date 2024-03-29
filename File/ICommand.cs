namespace architecture_assignment1_finale;

public interface IMyCommand
{
    public List<MyFile> Exec(string argument, List<MyFile> files);
}

