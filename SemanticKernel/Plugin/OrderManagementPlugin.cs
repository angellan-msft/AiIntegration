// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;

namespace ChatBot.SemanticKernel
{
    public class OrderManagementPlugin
    {
        private readonly List<Order> _orders;
        private readonly List<ReturnCase> _returns;
        private readonly List<PaymentTransaction> _payments;

        public OrderManagementPlugin()
        {
            // Sample Data
            // The data is currently hardcoded in this class for demonstration purposes.
            // In a real-world scenario, Contoso can choose their preferred data source 
            // (e.g., CRM, CosmosDB, File System) and implement the appropriate data access 
            // logic in the corresponding methods.
            
            _orders = new List<Order>
            {
                new Order { UserId = 110, OrderId = "ORD001", ProductName = "Laptop", Status = "The order has left the warehouse and is on its way to the customer", ShippedDate = "2024-12-01", EstimatedDeliveryDate = "2024-12-10" },
                new Order { UserId = 110, OrderId = "ORD002", ProductName = "Bluetooth Earphones", Status = "The order has been placed but not yet processed", ShippedDate = "", EstimatedDeliveryDate = "" },
                new Order { UserId = 110, OrderId = "ORD003", ProductName = "Power Bank", Status = "The order has been delivered to the customer.", ShippedDate = "2025-02-01", EstimatedDeliveryDate = "2025-02-07" }
            };
            
            _returns = new List<ReturnCase>
            {
                new ReturnCase { UserId = 110, ReturnId = "RET001", OrderId = "ORD003", ReturnReason = "Defective product", Status = "The return request has been submitted but not reviewed yet", ProcessedDate = null }
            };
            
            _payments = new List<PaymentTransaction>
            {
                new PaymentTransaction { UserId = 110, TransactionId = "TXN001", OrderId = "ORD002", PaymentStatus = "Failed", RefundStatus = "Not Initiated", PaymentDate = "2024-11-30", Amount = 799.99M }
            };
        }

        [KernelFunction("get_order_status")]
        [Description("Retrieves all orders for a given user. If an order is unprocessed, check the payment status. If the user only asks about the specific orders(eg. Laptop), don't check the other orders(Earphone & Power Bank).")]
        public async Task<List<Order>> FetchOrderStatusByUserId(int userId)
        {
            return _orders.Where(o => o.UserId == userId).ToList();
        }

        [KernelFunction("get_return_status_by_order")]
        [Description("Retrieves the return request status for a given Order ID. Use this after fetching an order to check if a return has been initiated.")]
        public async Task<ReturnCase?> FetchReturnCaseByOrderId(string orderId)
        {
            return _returns.FirstOrDefault(r => r.OrderId == orderId);
        }

        [KernelFunction("get_payment_status_by_order")]
        [Description("Retrieves the payment status for a given Order ID. Use this to determine if a payment failed or succeeded for an order.")]
        public async Task<PaymentTransaction?> FetchPaymentStatusByOrderId(string orderId)
        {
            return _payments.FirstOrDefault(p => p.OrderId == orderId);
        }
    }
}