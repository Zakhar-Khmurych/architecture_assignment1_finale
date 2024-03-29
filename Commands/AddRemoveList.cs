using System.Windows.Input;
using architecture_assignment1_finale;

namespace Commands;

public class AddCommand : IMyCommand
{
    public List<MyFile> Exec(string argument, List<MyFile> files)
    {
        string[] args = argument.Split(' ');
        if (args.Length < 1 || args.Length > 2)
        {
            Console.WriteLine("Usage: add <filename> [<shortcut>]");
            return files;
        }

        string filename = args[0];
        string shortcut = args.Length == 2 ? args[1] : Path.GetFileNameWithoutExtension(filename);

        files.Add(new MyFile(filename, shortcut));
        Console.WriteLine($"File '{filename}' added with shortcut '{shortcut}'");
        return files;
    }
}

public class RemoveCommand : IMyCommand
{
    public List<MyFile> Exec(string argument, List<MyFile> files)
    {
        string shortcut = argument.Trim();
        MyFile fileToRemove = files.FirstOrDefault(f => f.Name == shortcut);
        if (fileToRemove != null)
        {
            files.Remove(fileToRemove);
            Console.WriteLine($"File '{fileToRemove.Name}' removed");
        }
        else
        {
            Console.WriteLine($"File with shortcut '{shortcut}' not found");
        }
        return files;
    }
}

public class ListCommand : IMyCommand
{
    public List<MyFile> Exec(string argument, List<MyFile> files)
    {
        Console.WriteLine("Currently added files:");
        foreach (var file in files)
        {
            Console.WriteLine($"{file.Name} - {file.Path}");
        }
        return files;
    }
}


