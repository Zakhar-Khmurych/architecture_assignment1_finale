using System.Windows.Input;

namespace architecture_assignment1_finale;

public class FileSystem
{
    public List<MyFile> Files;
    public List<User> UserBase;
    public FileSystem()
    {
        Files = new List<MyFile>();
        UserBase = new List<User>();
    }

    public void Execute(IMyCommand command, string argument)
    {
        Files = command.Exec(argument, Files);
    }
}