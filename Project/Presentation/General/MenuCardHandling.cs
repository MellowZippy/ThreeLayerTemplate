using Newtonsoft.Json;

static class MenuCardHandling
{
    public static void DeleteItemFromMenu(int id)
    {
        List<FoodModel> objects = JsonConvert.DeserializeObject<List<FoodModel>>(File.ReadAllText("DataSources/food.json"))!;
    
        FoodModel objectToRemove = objects.Find(o => o.Id == id)!;
        if (objectToRemove != null)
        {
            objects.Remove(objectToRemove);
        }

        File.WriteAllText("DataSources/food.json", JsonConvert.SerializeObject(objects));
    }

    public static List<FoodModel> GetAllItems()
    {
        string json = File.ReadAllText("DataSources/food.json");
        return JsonConvert.DeserializeObject<List<FoodModel>>(json)!;
    }

    public static void MenuOptionsHandler(string option)
    {
        switch (option.ToUpper())
        {
            case "D":
                MenuCardGUI.DeleteItemFromMenuGUI();
                break;
            case "R":
                // DeleteAllItemsFromMenuCard();
                break;
            case "A": 
                // AddItemToMenu();
                break;    
            case "C":
                // ChangeItem()
                break;
            default:
                MenuCardGUI.ShowMenuOptions();
                break;
        }
    }
}