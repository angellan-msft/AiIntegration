using System.Text.Json.Serialization;

namespace ChatBot.SemanticKernel
{
    public class ReturnCase
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        
        [JsonPropertyName("return_id")]
        public string ReturnId { get; set; } = string.Empty;
        
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; } = string.Empty;
        
        [JsonPropertyName("return_reason")]
        public string ReturnReason { get; set; } = string.Empty;
        
        [JsonPropertyName("status")]
        public string Status { get; set; } = string.Empty;
        
        [JsonPropertyName("processed_date")]
        public string? ProcessedDate { get; set; }
    }
}