using Newtonsoft.Json;

static class MenuCardGUI
{
    static private FoodLogic _foodLogic = new FoodLogic();

    public static void ShowMenuCard()
    {
        List<FoodModel> foodList = MenuCardHandling.GetAllItems();

        foreach (FoodModel foodItem in foodList)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"| {foodItem.Id.ToString().PadLeft(2, '0')} | {foodItem.Name.PadLeft(20, '-')} | ${foodItem.Price.ToString().PadLeft(10, '-')} | {foodItem.Description.PadLeft(100, '-')} |");
        }
    }

    public static void ShowMenuOptions()
    {
        Console.WriteLine("What do you want to do with the menu?");
        Console.WriteLine("[D] Delete an item.");
        Console.WriteLine("[C] Change an item.");
        Console.WriteLine("[R] Remove all items.");
        Console.WriteLine("[A] Add an item to the menu");

        string option = Console.ReadLine() ?? "";

        MenuCardHandling.MenuOptionsHandler(option);
    }

    public static void DeleteItemFromMenuGUI()
    {
        Console.WriteLine("What item do you want to remove?");
        Console.Write("ID: ");
        
        string input = Console.ReadLine()!;

        if (string.IsNullOrEmpty(input))
        {
            Console.Clear();
            Console.WriteLine("Input cannot be empty. Please try again.");
            DeleteItemFromMenuGUI();
        }

        if (!int.TryParse(input, out int id))
        {
            Console.Clear();
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            DeleteItemFromMenuGUI();
        }

        MenuCardHandling.DeleteItemFromMenu(id);
    }

    public static void AddItemToMenuGUI()
    {
        Console.WriteLine("What will be the name of the dish?");
        string DishName = Console.ReadLine() ?? "";
        Console.WriteLine("What will be the price of the dish?");
        string DishPrice = Console.ReadLine() ?? ""; // Still needs to be converted to int.
        Console.WriteLine("How will the food be described?");
        string DishDescription = Console.ReadLine() ?? ""; 
        Console.WriteLine("What category of food does this dish belong to?");
        string DishCategory = Console.ReadLine() ?? "";
    }

}