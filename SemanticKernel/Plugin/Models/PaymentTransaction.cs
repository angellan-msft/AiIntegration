using System.Text.Json.Serialization;

namespace ChatBot.SemanticKernel
{
    public class PaymentTransaction
    {
        [JsonPropertyName("user_id")]
        public int UserId { get; set; }
        
        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; } = string.Empty;
        
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; } = string.Empty;
        
        [JsonPropertyName("payment_status")]
        public string PaymentStatus { get; set; } = string.Empty;
        
        [JsonPropertyName("refund_status")]
        public string? RefundStatus { get; set; }
        
        [JsonPropertyName("payment_date")]
        public string? PaymentDate { get; set; }
        
        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }
    }
}