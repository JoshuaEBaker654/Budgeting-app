
namespace BudgetTracker;

public class Expenses
{
    private decimal amount;
    public decimal Amount
    {
        get{return amount;}
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("Please provide a positive amount.");
            }

            amount = value;
        }
    }

    private string category;

    public string Category
    {
        get { return category;}
        set
        {
            switch (value)
            {
                case "1":
                {
                    category = "Housing";
                    break;;
                }
                case "2":
                {
                    category = "Transportation";
                    break;
                }
                case "3":
                {
                    category = "Food";
                    break;
                }
                case "4":
                {
                    category = "Utilities";
                    break;
                }
                case "5":
                {
                    category = "Insurance";
                    break;
                }
                case "6":
                {
                    category = "Dept Payments";
                    break;
                }
                case "7":
                {
                    category = "Healthcare";
                    break;
                }
                case "8":
                {
                    category = "Clothing";
                    break;
                }
                case "9":
                {
                    category = "Children/Education";
                    break;
                }
                case "10":
                {
                    category = "Entertainment";
                    break;
                }
                case "11":
                {
                    category = "Emergency fund";
                    break;
                }
                case "12":
                {
                    category = "Other";
                    break;
                }
            }
        }
    }
    public DateTime Date { get; set; }
    public string Description { get; set; }

    public Expenses()
    {
        Amount = 0;
        Category = "Other";
        Date = DateTime.Now;
        Description = "None";
    }

    public Expenses(decimal aAmount, string aCategory, DateTime aDate, string aDescription)
    {
        Amount = aAmount;
        Category = aCategory;
        Date = aDate;
        Description = aDescription;
    }
}