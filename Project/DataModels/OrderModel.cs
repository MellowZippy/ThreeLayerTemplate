using System.Text.Json.Serialization;

public class OrderModel
{
    [JsonPropertyName("orderId")]
    public int orderId { get; set; }

    [JsonPropertyName("totalPrice")]
    public int totalPrice { get; set; }

    public OrderModel(int order_id, int total_price)
    {
        orderId = order_id;
        totalPrice = total_price;
    }
}