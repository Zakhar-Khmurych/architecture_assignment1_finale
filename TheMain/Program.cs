// See https://aka.ms/new-console-template for more information

using architecture_assignment1_finale;
using Commands;
using TheMain;

//MyFile mf1 = new MyFile("path", "name");

//FileSystem fs1 = new FileSystem();

//AddCommand add = new AddCommand();
//ListCommand lst = new ListCommand();

//fs1.Execute(add, "path2 name2");

Console.WriteLine("Hello, World!");

//fs1.Execute(lst, "");

CommandHandler handler = new CommandHandler();
handler.ReadConsole();



