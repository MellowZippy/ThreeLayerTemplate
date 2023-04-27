static class AdminGUI
{
    public static void AdminUI()
    { 
        Console.Clear();
        Console.WriteLine("Enter 1 to see all reservations");
        Console.WriteLine("Enter 2 to see Menu");
        Console.WriteLine("Enter 3 to change the Menu");
        Console.WriteLine("Enter 4 to change Restaurant Layout");
        Console.WriteLine("Enter 5 to change Restaurant Information");
        Console.WriteLine("Enter 6 to Quit");
        Console.WriteLine("Admin commands:");
        Console.WriteLine("Enter 'A' to search an account");
        Console.WriteLine("Enter 'B' to see the accounts ordered");
        Console.WriteLine("Enter 'C' to search a dish");
        Console.WriteLine("Enter 'D' to see the food ordered");
        Console.WriteLine("Enter 'E' to search a reservation");
        Console.WriteLine("Enter 'F' to see the reservations ordered");
        Console.WriteLine("Enter 'back' to go to the home screen");

        string choice = Console.ReadLine() ?? "";

        AdminHandling.AdminCommandHandling(choice);
    }
}