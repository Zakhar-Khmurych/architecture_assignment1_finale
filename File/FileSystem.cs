using System.Windows.Input;

namespace architecture_assignment1_finale;

public class FileSystem
{
    public List<MyFile> Files;

    public FileSystem()
    {
        Files = new List<MyFile>();
    }

    public void Execute(IMyCommand command, string argument)
    {
        Files = command.Exec(argument, Files);
    }
}