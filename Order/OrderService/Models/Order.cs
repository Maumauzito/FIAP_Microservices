using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<OrderItem> Items { get; set; } = new();
        public bool IsPaid { get; set; } = false;
    }
}