using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
namespace BudgetTracker;

class Program
{
    static void Main(string[] args)
    {
        OurList<Expenses>  expenses = new OurList<Expenses>();
        // Console.WriteLine("Would you like to access \"Expense Tracker\" y/n");
        // string input = Console.ReadLine().ToLower();
        bool running = true;
        while (running)
        {
            
                Console.WriteLine("\n== Expense Tracker ==\n");
                Console.WriteLine("1: Add expense");
                Console.WriteLine("2: View Monthly Report");
                Console.WriteLine("3: Save to File");
                Console.WriteLine("4: Load from File");
                Console.WriteLine("5: Exit");
                Console.WriteLine("\nSelect an Option: (by number)");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                    {
                        Console.WriteLine("Please provide an amount for this expense:");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Please identify the category of the expense from the following list: (by number)");
                        Console.WriteLine("1: Housing");
                        Console.WriteLine("2: Transportation");
                        Console.WriteLine("3: Food");
                        Console.WriteLine("4: Utilities");
                        Console.WriteLine("5: Insurance");
                        Console.WriteLine("6: Dept Payments");
                        Console.WriteLine("7: Healthcare");
                        Console.WriteLine("8: Clothing");
                        Console.WriteLine("9: Transportation");
                        Console.WriteLine("10: Entertainment");
                        Console.WriteLine("11: Emergency fund");
                        Console.WriteLine("12: Other");

                        string category = "12"; 
                        category = Console.ReadLine();
                        
                        Console.WriteLine("Please provide a date for this expense: ex:(01/10/2024)");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        
                        Console.WriteLine("Optional: Provide a description:");
                        string description = "None";
                        description= Console.ReadLine();
                        
                        expenses.AddFront(new Expenses(amount, category, date, description));
                        Console.WriteLine("Expense added.");
                        
                        break;
                    }
                    case "2":
                    {
                        Console.WriteLine("Uh oh there isn't anything here yet.");
                        break;
                    }
                    case "3":
                    {
                        Console.WriteLine("Please provide a file name.");
                        string save = Console.ReadLine();
                        FileManager.SaveToFile(save, expenses);
                        Console.WriteLine("File saved.");
                        break;
                    }
                    case "4":
                    {
                        Console.WriteLine("What file would you like to load?");
                        string load = Console.ReadLine();
                        FileManager.LoadFromFile(load, expenses);
                        Console.WriteLine("Files loaded.");
                        break;
                    }
                    case "5":
                    {
                        Console.WriteLine("Thank you for using Budget Tracker.");
                        running = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                    }
                }
        }
        Console.WriteLine("Thank you!");
        
    }
}