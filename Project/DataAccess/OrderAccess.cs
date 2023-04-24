using System.Text.Json;

static class OrderAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/orders.json"));

    public static List<OrderModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<OrderModel>>(json)!;
    }

    public static void WriteAll(List<OrderModel> orders)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(orders, options);
        File.WriteAllText(path, json);
    }

}