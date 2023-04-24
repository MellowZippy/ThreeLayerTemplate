using System.Text.Json.Serialization;

public class CustomerModel
{
    [JsonPropertyName("customerId")]
    public int customerId { get; set; }

    [JsonPropertyName("orderId")]
    public int orderId { get; set; }

    [JsonPropertyName("accountId")]
    public int accountId { get; set; }

    public CustomerModel(int customer_id, int order_id, int account_id)
    {
        customerId = customer_id;
        orderId = order_id;
        accountId = account_id;
    }
}




