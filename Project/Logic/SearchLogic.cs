class SearchLogic
{
    // search an item based on users input
    public static void SearchItemStart(string TypeItem)
    {
        if (TypeItem == "Accounts") AccountsSearch();
        if (TypeItem == "Food") FoodSearch();
        if (TypeItem == "Reservations") ReservationsSearch();
    }

    // orders the pages by users liking
    public static void OrderByStart(string ToOrderBy)
    {
        if (ToOrderBy == "Accounts") AccountsOrderBy();
        if (ToOrderBy == "Food") FoodOrderBy();
        if (ToOrderBy == "Reservations") ReservationOrderBy();
    }

    // user chooses how to search; the search options are inputted in the Search functions: AccountsSearch(), FoodSearch() and ReservationsSearch().
    public static string SearchOptionsMenu(List<string> searchOptions)
    {
        Menu.Print();
        Console.WriteLine("How do you want to search?");
        for (int i = 0; i < searchOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}) Search by {searchOptions[i]}");
        }
        int action = int.Parse(Console.ReadLine() ?? "0");
        Console.Clear();
        for (int i = 0; i < searchOptions.Count; i++)
        {
            if (action == i + 1) return searchOptions[i];
        }
        return "invalid";
    }

    // user chooses how they want to order the data; order by id or name.
    public static string OrderByMenu(List<string> OrderOptions)
    {
        Menu.Print();
        Console.WriteLine("How do you want it to be displayed?");
        for (int i = 0; i < OrderOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}) Order by {OrderOptions[i]}");
        }
        int action = int.Parse(Console.ReadLine() ?? "0");
        Console.Clear();
        for (int i = 0; i < OrderOptions.Count; i++)
        {
            if (action == i + 1) return OrderOptions[i];
        }
        return "invalid";
    }

    // user enters what they want to search, and every item thats the same as the userSearch, gets printed.
    public static void AccountsSearch()
    {
        List<AccountModel> Accounts = AccountsAccess.LoadAll();
        List<string> searchOptions = new List<string> { "id", "name", "email" };
        string menuMessage = "";
        for (int i = 1; i < searchOptions.Count; i++) { menuMessage += $"{i}, "; }
        menuMessage = menuMessage.Remove(menuMessage.Length - 2);
        menuMessage += searchOptions.Count.ToString();
        Menu.message = "Search an account:";
        string searchMethod = SearchOptionsMenu(searchOptions);
        while (searchMethod == "invalid") { Menu.message = $"Your input was invalid; choose between {menuMessage}"; searchMethod = SearchOptionsMenu(searchOptions); }
        Console.WriteLine($"Enter the {searchMethod} you want to search");
        string userSearch = (Console.ReadLine() ?? "").TrimEnd();
        Console.WriteLine($"| {"id".PadLeft(4, ' ')} | {"Full name".PadLeft(30, ' ')} | {"Email Address".PadLeft(30, ' ')} | {"Password".PadLeft(20, ' ')} |");
        Console.WriteLine($"|-{"".PadLeft(4, '-')}-|-{"".PadLeft(30, '-')}-|-{"".PadLeft(30, '-')}-|-{"".PadLeft(20, '-')}-|");
        if (searchMethod == "id")
        {
            foreach (AccountModel acc in Accounts)
            {
                if (acc.Id.ToString() == userSearch)
                {
                    string accountInfo = $"| {acc.Id.ToString().PadLeft(4, ' ')} | {acc.FullName.PadLeft(30, ' ')} | {acc.EmailAddress.PadLeft(30, ' ')} | {acc.Password.PadLeft(20, ' ')} |";
                    Console.WriteLine(accountInfo);
                }
            }
        }
        else if (searchMethod == "name")
        {
            foreach (AccountModel acc in Accounts)
            {
                if (acc.FullName.ToLower() == userSearch.ToLower())
                {
                    string accountInfo = $"| {acc.Id.ToString().PadLeft(4, ' ')} | {acc.FullName.PadLeft(30, ' ')} | {acc.EmailAddress.PadLeft(30, ' ')} | {acc.Password.PadLeft(20, ' ')} |";
                    Console.WriteLine(accountInfo);
                }
            }
        }
        else if (searchMethod == "email")
        {
            foreach (AccountModel acc in Accounts)
            {
                if (acc.EmailAddress.ToLower() == userSearch.ToLower())
                {
                    string accountInfo = $"| {acc.Id.ToString().PadLeft(4, ' ')} | {acc.FullName.PadLeft(30, ' ')} | {acc.EmailAddress.PadLeft(30, ' ')} | {acc.Password.PadLeft(20, ' ')} |";
                    Console.WriteLine(accountInfo);
                }
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
        Menu.PressEnter();
        Menu.HandleLogin();
    }

    // data gets displayed ordered by the user's preference.
    public static void AccountsOrderBy()
    {
        List<string> orderOptions = new List<string> { "id", "name" };
        string menuMessage = "";
        for (int i = 1; i < orderOptions.Count; i++) { menuMessage += $"{i}, "; }
        menuMessage = menuMessage.Remove(menuMessage.Length - 2);
        menuMessage += orderOptions.Count.ToString();
        Menu.message = "Order accounts by:";
        string orderMethod = OrderByMenu(orderOptions);
        while (orderMethod == "invalid") { Menu.message = $"Your input was invalid; choose between {menuMessage}"; orderMethod = OrderByMenu(orderOptions); }
        Console.WriteLine($"| {"id".PadLeft(4, ' ')} | {"Full name".PadLeft(30, ' ')} | {"Email Address".PadLeft(30, ' ')} | {"Password".PadLeft(20, ' ')} |");
        Console.WriteLine($"|-{"".PadLeft(4, '-')}-|-{"".PadLeft(30, '-')}-|-{"".PadLeft(30, '-')}-|-{"".PadLeft(20, '-')}-|");
        if (orderMethod == "id")
        {
            List<AccountModel> Accounts = AccountsAccess.AscIDMyJson();
            foreach (AccountModel acc in Accounts)
            {
                string accountInfo = $"| {acc.Id.ToString().PadLeft(4, ' ')} | {acc.FullName.PadLeft(30, ' ')} | {acc.EmailAddress.PadLeft(30, ' ')} | {acc.Password.PadLeft(20, ' ')} |";
                Console.WriteLine(accountInfo);
            }
        }
        else if (orderMethod == "name")
        {
            List<AccountModel> Accounts = AccountsAccess.AscNameMyJson();
            foreach (AccountModel acc in Accounts)
            {
                string accountInfo = $"| {acc.Id.ToString().PadLeft(4, ' ')} | {acc.FullName.PadLeft(30, ' ')} | {acc.EmailAddress.PadLeft(30, ' ')} | {acc.Password.PadLeft(20, ' ')} |";
                Console.WriteLine(accountInfo);
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
        Menu.PressEnter();
        Menu.HandleLogin();
    }

    public static void FoodSearch()
    {
        List<FoodModel> Food = FoodAccess.LoadAll();
        List<string> searchOptions = new List<string> { "id", "name" };
        string menuMessage = "";
        for (int i = 1; i < searchOptions.Count; i++) { menuMessage += $"{i}, "; }
        menuMessage = menuMessage.Remove(menuMessage.Length - 2);
        menuMessage += searchOptions.Count.ToString();
        Menu.message = "Search a dish:";
        string searchMethod = SearchOptionsMenu(searchOptions);
        while (searchMethod == "invalid") { Menu.message = $"Your input was invalid; choose between {menuMessage}"; searchMethod = SearchOptionsMenu(searchOptions); }
        Console.WriteLine($"Enter the {searchMethod} you want to search");
        string userSearch = (Console.ReadLine() ?? "").TrimEnd();
        Console.WriteLine($"| {"id".PadLeft(4, ' ')} | {"Name".PadLeft(30, ' ')} | {"Price".PadLeft(30, ' ')} | {"Description".PadLeft(80, ' ')} |");
        Console.WriteLine($"|-{"".PadLeft(4, '-')}-|-{"".PadLeft(30, '-')}-| {"".PadLeft(30, '-')}-| {"".PadLeft(80, '-')}-|");
        if (searchMethod == "id")
        {
            foreach (FoodModel dish in Food)
            {
                if (dish.Id.ToString() == userSearch)
                {
                    string dishInfo = $"| {dish.Id.ToString().PadLeft(4, ' ')} | {dish.Name.PadLeft(30, ' ')} | ${dish.Price.ToString().PadLeft(29, ' ')} | {dish.Description.PadLeft(80, ' ')} |";
                    Console.WriteLine(dishInfo);
                }
            }
        }
        else if (searchMethod == "name")
        {
            foreach (FoodModel dish in Food)
            {
                if (dish.Name.ToLower() == userSearch.ToLower())
                {
                    string dishInfo = $"| {dish.Id.ToString().PadLeft(4, ' ')} | {dish.Name.PadLeft(30, ' ')} | {dish.Price.ToString().PadLeft(30, ' ')} | {dish.Description.PadLeft(20, ' ')} |";
                    Console.WriteLine(dishInfo);
                }
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
        Menu.PressEnter();
        Menu.HandleLogin();
    }

    public static void FoodOrderBy()
    {
        List<string> orderOptions = new List<string> { "id", "name", "price" };
        string menuMessage = "";
        for (int i = 1; i < orderOptions.Count; i++) { menuMessage += $"{i}, "; }
        menuMessage = menuMessage.Remove(menuMessage.Length - 2);
        menuMessage += orderOptions.Count.ToString();
        Menu.message = "Order food by:";
        string orderMethod = OrderByMenu(orderOptions);
        while (orderMethod == "invalid") { Menu.message = $"Your input was invalid; choose between {menuMessage}"; orderMethod = OrderByMenu(orderOptions); }
        Console.WriteLine($"| {"id".PadLeft(4, ' ')} | {"Name".PadLeft(30, ' ')} | {"Price".PadLeft(30, ' ')} |");
        Console.WriteLine($"|-{"".PadLeft(4, '-')}-|-{"".PadLeft(30, '-')}-| ${"".PadLeft(30, '-')}-|");
        if (orderMethod == "id")
        {
            List<FoodModel> Food = FoodAccess.AscIDMyJson();
            foreach (FoodModel dish in Food)
            {
                string dishInfo = $"| {dish.Id.ToString().PadLeft(4, ' ')} | {dish.Name.PadLeft(30, ' ')} | {dish.Price.ToString().PadLeft(30, ' ')} |";
                Console.WriteLine(dishInfo);
            }
        }
        else if (orderMethod == "name")
        {
            List<FoodModel> Food = FoodAccess.AscNameMyJson();
            foreach (FoodModel dish in Food)
            {
                string dishInfo = $"| {dish.Id.ToString().PadLeft(4, ' ')} | {dish.Name.PadLeft(30, ' ')} | {dish.Price.ToString().PadLeft(30, ' ')} |";
                Console.WriteLine(dishInfo);
            }
        }
        else if (orderMethod == "price")
        {
            List<FoodModel> Food = FoodAccess.AscPriceMyJson();
            foreach (FoodModel dish in Food)
            {
                string dishInfo = $"| {dish.Id.ToString().PadLeft(4, ' ')} | {dish.Name.PadLeft(30, ' ')} | {dish.Price.ToString().PadLeft(30, ' ')} |";
                Console.WriteLine(dishInfo);
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
        Menu.PressEnter();
        Menu.HandleLogin();
    }

    public static void ReservationsSearch()
    {
        List<ReservationModel> Reservations = ReservationsAccess.LoadAll();
        List<string> searchOptions = new List<string> { "id", "name", "date", "people" };
        string menuMessage = "";
        for (int i = 1; i < searchOptions.Count; i++) { menuMessage += $"{i}, "; }
        menuMessage = menuMessage.Remove(menuMessage.Length - 2);
        menuMessage += searchOptions.Count.ToString();
        Menu.message = "Search a reservation:"
; string searchMethod = SearchOptionsMenu(searchOptions);
        while (searchMethod == "invalid") { Menu.message = $"Your input was invalid; choose between {menuMessage}"; searchMethod = SearchOptionsMenu(searchOptions); }
        Console.WriteLine($"Enter the {searchMethod} you want to search");
        string userSearch = (Console.ReadLine() ?? "").TrimEnd();
        Console.WriteLine($"| {"id".PadLeft(4, ' ')} | {"Full name".PadLeft(30, ' ')} | {"Email Address".PadLeft(30, ' ')} | {"Password".PadLeft(20, ' ')} |");
        Console.WriteLine($"|-{"".PadLeft(4, '-')}-|-{"".PadLeft(30, '-')}-|-{"".PadLeft(30, '-')}-|-{"".PadLeft(20, '-')}-|");
        if (searchMethod == "id")
        {
            foreach (ReservationModel res in Reservations)
            {
                if (res.Id.ToString() == userSearch)
                {
                    string reservationInfo = $"| {res.Id.ToString().PadLeft(4, ' ')} | {res.FullName.PadLeft(30, ' ')} | {res.Date.ToString().PadLeft(30, ' ')} | {res.QuantityPeople.ToString().PadLeft(20, ' ')} |";
                    Console.WriteLine(reservationInfo);
                }
            }
        }
        else if (searchMethod == "name")
        {
            foreach (ReservationModel res in Reservations)
            {
                if (res.FullName == userSearch)
                {
                    string reservationInfo = $"| {res.Id.ToString().PadLeft(4, ' ')} | {res.FullName.PadLeft(30, ' ')} | {res.Date.ToString().PadLeft(30, ' ')} | {res.QuantityPeople.ToString().PadLeft(20, ' ')} |";
                    Console.WriteLine(reservationInfo);
                }
            }
        }
        else if (searchMethod == "date")
        {
            foreach (ReservationModel res in Reservations)
            {
                if (res.Date.ToString() == userSearch)
                {
                    string reservationInfo = $"| {res.Id.ToString().PadLeft(4, ' ')} | {res.FullName.PadLeft(30, ' ')} | {res.Date.ToString().PadLeft(30, ' ')} | {res.QuantityPeople.ToString().PadLeft(20, ' ')} |";
                    Console.WriteLine(reservationInfo);
                }
            }
        }
        else if (searchMethod == "people")
        {
            foreach (ReservationModel res in Reservations)
            {
                if (res.QuantityPeople.ToString() == userSearch)
                {
                    string reservationInfo = $"| {res.Id.ToString().PadLeft(4, ' ')} | {res.FullName.PadLeft(30, ' ')} | {res.Date.ToString().PadLeft(30, ' ')} | {res.QuantityPeople.ToString().PadLeft(20, ' ')} |";
                    Console.WriteLine(reservationInfo);
                }
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
        Menu.PressEnter();
        Menu.HandleLogin();
    }

    public static void ReservationOrderBy()
    {
        List<string> orderOptions = new List<string> { "id", "name", "date", "people" };
        string menuMessage = "";
        for (int i = 1; i < orderOptions.Count; i++) { menuMessage += $"{i}, "; }
        menuMessage = menuMessage.Remove(menuMessage.Length - 2);
        menuMessage += orderOptions.Count.ToString();
        Menu.message = "Order reservations by:";
        string orderMethod = OrderByMenu(orderOptions);
        while (orderMethod == "invalid") { Menu.message = $"Your input was invalid; choose between {menuMessage}"; orderMethod = OrderByMenu(orderOptions); }
        Console.WriteLine($"| {"id".PadLeft(4, ' ')} | {"Full name".PadLeft(30, ' ')} | {"Date".PadLeft(30, ' ')} | {"Quantity people".PadLeft(20, ' ')} |");
        Console.WriteLine($"|-{"".PadLeft(4, '-')}-|-{"".PadLeft(30, '-')}-|-{"".PadLeft(30, '-')}-|-{"".PadLeft(20, '-')}-|");
        if (orderMethod == "id")
        {
            List<ReservationModel> Reservations = ReservationsAccess.AscIDMyJson();
            foreach (ReservationModel res in Reservations)
            {
                string reservationInfo = $"| {res.Id.ToString().PadLeft(4, ' ')} | {res.FullName.PadLeft(30, ' ')} | {res.Date.ToString().PadLeft(30, ' ')} | {res.QuantityPeople.ToString().PadLeft(20, ' ')} |";
                Console.WriteLine(reservationInfo);
            }
        }
        else if (orderMethod == "name")
        {
            List<ReservationModel> Reservations = ReservationsAccess.AscNameMyJson();
            foreach (ReservationModel res in Reservations)
            {
                string reservationInfo = $"| {res.Id.ToString().PadLeft(4, ' ')} | {res.FullName.PadLeft(30, ' ')} | {res.Date.ToString().PadLeft(30, ' ')} | {res.QuantityPeople.ToString().PadLeft(20, ' ')} |";
                Console.WriteLine(reservationInfo);
            }
        }
        else if (orderMethod == "date")
        {
            List<ReservationModel> Reservations = ReservationsAccess.AscDateMyJson();
            foreach (ReservationModel res in Reservations)
            {
                string reservationInfo = $"| {res.Id.ToString().PadLeft(4, ' ')} | {res.FullName.PadLeft(30, ' ')} | {res.Date.ToString().PadLeft(30, ' ')} | {res.QuantityPeople.ToString().PadLeft(20, ' ')} |";
                Console.WriteLine(reservationInfo);
            }
        }
        else if (orderMethod == "people")
        {
            List<ReservationModel> Reservations = ReservationsAccess.AscPeopleMyJson();
            foreach (ReservationModel res in Reservations)
            {
                string reservationInfo = $"| {res.Id.ToString().PadLeft(4, ' ')} | {res.FullName.PadLeft(30, ' ')} | {res.Date.ToString().PadLeft(30, ' ')} | {res.QuantityPeople.ToString().PadLeft(20, ' ')} |";
                Console.WriteLine(reservationInfo);
            }
        }
        else
        {
            Console.WriteLine("Error");
        }
        Menu.PressEnter();
        Menu.HandleLogin();
    }
}