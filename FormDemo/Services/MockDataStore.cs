using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormDemo.Models;

namespace FormDemo.Services
{
    public class MockDataStore : IDataStore<Order>
    {
        readonly List<Order> items;

        public MockDataStore()
        {
            items = new List<Order>()
            {
                new Order { Id = Guid.NewGuid().ToString(), QueueNumber = "1", CashierName = "Hoang", Description="Ready All" },
                new Order { Id = Guid.NewGuid().ToString(), QueueNumber = "2", CashierName = "Hoang", Description="Ready All" },
                new Order { Id = Guid.NewGuid().ToString(), QueueNumber = "3", CashierName = "Hoang", Description="Ready All" },
                new Order { Id = Guid.NewGuid().ToString(), QueueNumber = "4", CashierName = "Hoang", Description="Ready All" },
                new Order { Id = Guid.NewGuid().ToString(), QueueNumber = "5", CashierName = "Hoang", Description="Ready All" },
                new Order { Id = Guid.NewGuid().ToString(), QueueNumber = "6", CashierName = "Hoang", Description="Ready All" },
                new Order { Id = Guid.NewGuid().ToString(), QueueNumber = "7", CashierName = "Hoang", Description="Ready All" },
                new Order { Id = Guid.NewGuid().ToString(), QueueNumber = "8", CashierName = "Hoang", Description="Ready All" },
            };
            
            for (var i = 0; i < items.Count; i ++)
            {
                items[i].LineItems = new List<LineItem>();
                for (int j = 0; j < i + 1; j++)
                {
                    items[i].LineItems.Add(new LineItem() {Id = Guid.NewGuid().ToString(), Name = "Chicken Nugget", Description = "Accepted"});
                }
               
                items[i].TotalItems = items[i].LineItems.Count.ToString();
                items[i].HeightRequest = items[i].LineItems.Count * 80; 
            }
            
        }

        public async Task<bool> AddItemAsync(Order order)
        {
            items.Add(order);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Order order)
        {
            var oldItem = items.Where((Order arg) => arg.Id == order.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(order);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Order arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Order> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Order>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
