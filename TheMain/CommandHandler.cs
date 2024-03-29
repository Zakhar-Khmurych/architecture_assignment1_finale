using architecture_assignment1_finale;

namespace TheMain;
using architecture_assignment1_finale;
using Commands;
public class CommandHandler
{
    public FileSystem FileSystem;
    private string Input;
    public bool Running;

    public CommandHandler()
    {
        Running = true;
        FileSystem = new FileSystem();
    }
    
    public void ReadConsole()
    {
        Console.WriteLine("The program is running! Write your commands:");
        while (Running)
        {
            Input = Console.ReadLine().ToLower();
            if (Input == "exit")
            {
                Running = false;
                Console.WriteLine("Exiting...");
            }
            else
            {
                string[] args = Input.Split(' ');
                if (args[0] == "add")
                {
                    AddCommand add = new AddCommand();
                    Input = string.Join(" ", args.Skip(1));
                    FileSystem.Execute(add, Input);
                }  
                if (args[0] == "remove" || args[0] == "delete")
                {
                    RemoveCommand remove = new RemoveCommand();
                    Input = string.Join(" ", args.Skip(1));
                    FileSystem.Execute(remove, Input);
                }
                if (args[0] == "list")
                {
                    ListCommand list = new ListCommand();
                    Input = string.Join(" ", args.Skip(1));
                    FileSystem.Execute(list, Input);
                }  
                if (args[0] == "options")
                {
                    if (args[1] == "summary")
                    {
                        SummaryTxt summary = new SummaryTxt();
                        Input = string.Join(" ", args.Skip(2));
                        FileSystem.Execute(summary, Input);
                    }
                    if (args[1] == "print")
                    {
                        PrintCsv printCsv = new PrintCsv();
                        Input = string.Join(" ", args.Skip(2));
                        FileSystem.Execute(printCsv, Input);
                    }  
                    if (args[1] == "validate")
                    {
                        ValidateJsonCsv validate = new ValidateJsonCsv();
                        Input = string.Join(" ", args.Skip(2));
                        FileSystem.Execute(validate, Input);
                    }  
                }


            }

         
            
            
        }
    }
    
    
}