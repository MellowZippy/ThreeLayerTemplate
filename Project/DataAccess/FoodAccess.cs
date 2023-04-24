using System.Text.Json;

static class FoodAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/food.json"));

    public static List<FoodModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<FoodModel>>(json)!;
    }

    public static void WriteAll(List<FoodModel> accounts)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(accounts, options);
        File.WriteAllText(path, json);
    }

    public static List<FoodModel> AscIDMyJson()
    {
        string json = File.ReadAllText(FoodAccess.path);
        var listOb = JsonSerializer.Deserialize<List<FoodModel>>(json);
        var descListOb = listOb!.OrderBy(x => x.Id).ToList();
        return descListOb;
    }

    public static List<FoodModel> AscNameMyJson()
    {
        string json = File.ReadAllText(FoodAccess.path);
        var listOb = JsonSerializer.Deserialize<List<FoodModel>>(json);
        var descListOb = listOb!.OrderBy(x => x.Name).ToList();
        return descListOb;
    }

    public static List<FoodModel> AscPriceMyJson()
    {
        string json = File.ReadAllText(FoodAccess.path);
        var listOb = JsonSerializer.Deserialize<List<FoodModel>>(json);
        var descListOb = listOb!.OrderBy(x => x.Price).ToList();
        return descListOb;
    }
}