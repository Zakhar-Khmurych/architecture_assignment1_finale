using System.Text.Json;
using System.Windows.Input;
using System.Xml;
using architecture_assignment1_finale;

namespace Commands;

public class SummaryTxt : IMyCommand
{
    public List<MyFile> Exec(string argument, List<MyFile> files)
    {
        MyFile file = files.FirstOrDefault(f => f.Path == argument && Path.GetExtension(f.Name) == ".txt");
        if (file != null)
        {
            string content = file.Content;
            int symbolCount = content.Length;
            int wordCount = content.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
            int paragraphCount = content.Split(new string[] { "\r\n\r\n", "\n\n" }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"Symbols: {symbolCount}, Words: {wordCount}, Paragraphs: {paragraphCount}");
            //MyFile summary = new MyFile(file.Path, "Summary of " + file.Name);
            //summary.Content = $"Symbols: {symbolCount}, Words: {wordCount}, Paragraphs: {paragraphCount}";
            //files.Add(summary);
        }
        return files;
    }
}

public class PrintCsv : IMyCommand
{
    public List<MyFile> Exec(string argument, List<MyFile> files)
    {
        MyFile file = files.FirstOrDefault(f => f.Path == argument && Path.GetExtension(f.Name) == ".csv");
       
        if (file != null)
        {
            if (file.Name.Contains(".csv"))
            {
                string content = file.Content;
                Console.WriteLine(content);
            }
            else if (file.Name.Contains(".json"))
            {
                try
                {
                    string content = File.ReadAllText(file.Path);
                    JsonDocument jsonDoc = JsonDocument.Parse(content);
                    JsonElement root = jsonDoc.RootElement;
                    string formattedJson = JsonSerializer.Serialize(root);
                    Console.WriteLine(formattedJson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error printing JSON: {ex.Message}");
                }
            }
        }
        return files;
    }
}
public class PrintJSON : IMyCommand
{
    public List<MyFile> Exec(string argument, List<MyFile> files)
    {
        MyFile file = files.FirstOrDefault(f => f.Path == argument && Path.GetExtension(f.Name) == ".json");
        if (file != null)
        {
            try
            {
                string content = File.ReadAllText(file.Path);
                JsonDocument jsonDoc = JsonDocument.Parse(content);
                JsonElement root = jsonDoc.RootElement;
                string formattedJson = JsonSerializer.Serialize(root);
                Console.WriteLine(formattedJson);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error printing JSON: {ex.Message}");
            }
        }
        return files;
    }
}

public class ValidateJsonCsv : IMyCommand
{
    public List<MyFile> Exec(string argument, List<MyFile> files)
    {
        MyFile file = files.FirstOrDefault(f => f.Path == argument);
        if (file != null)
        {
            if (Path.GetExtension(file.Name) == ".json")
            {
                try
                {
                    string content = File.ReadAllText(file.Path);
                    JsonDocument.Parse(content);
                    Console.WriteLine("JSON is valid.");
                }
                catch (JsonException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else if (Path.GetExtension(file.Name) == ".csv")
            {
                Console.WriteLine("CSV validation not implemented.");
            }
            else
            {
                Console.WriteLine("Unsupported file type.");
            }
        }
        return files;
    }
}










