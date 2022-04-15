using System;
using System.Collections.Generic;

namespace FormDemo.Models
{
    public class Order
    {
        public string Id { get; set; }
        public string QueueNumber { get; set; }
        public int TotalItems { get; set; }
        public string CashierName { get; set; }
        public string Description { get; set; }
        public List<LineItem> LineItems { get; set; }
        public DateTime CreatedAt { get; set; }
        public int HeightRequest { get; set; }
    }
}
