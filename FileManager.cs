namespace BudgetTracker;
using System.Text.Json;

public static class FileManager
{
    public static void SaveToFile(string fileName, OurList<Expenses> expenses)
    {
        var list = expenses.ToList();
        string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
    }

    public static void LoadFromFile(string fileName, OurList<Expenses> expenses)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"File {fileName} does not exist");
            return;
        }
        
        string json = File.ReadAllText(fileName);
        var list = JsonSerializer.Deserialize<List<Expenses>>(json);
        expenses.LoadFromList(list);
    }
}