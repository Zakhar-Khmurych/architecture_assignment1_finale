using System.Windows.Input;
using architecture_assignment1_finale;

namespace Commands;

public class Login : IMyCommand
{
    public List<MyFile> Exec(string argument, List<MyFile> files)
    {
        return files;
    }
}