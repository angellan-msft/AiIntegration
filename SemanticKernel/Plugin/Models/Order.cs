using System.Text.Json.Serialization;

namespace ChatBot.SemanticKernel
{
    public class Order
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; } = string.Empty;
        
        [JsonPropertyName("product_name")]
        public string ProductName { get; set; } = string.Empty;
        
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
        
        [JsonPropertyName("shipped_date")]
        public string? ShippedDate { get; set; }
        
        [JsonPropertyName("estimated_delivery_date")]
        public string? EstimatedDeliveryDate { get; set; }
    }
}