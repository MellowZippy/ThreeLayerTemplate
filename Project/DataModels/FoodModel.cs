using System.Text.Json.Serialization;


public class FoodModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("price")]
    public double Price { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("category")]
    public string Category { get; set; }

    public FoodModel(int id, string name, double price, string description, string category)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        Category = category;
    }
}