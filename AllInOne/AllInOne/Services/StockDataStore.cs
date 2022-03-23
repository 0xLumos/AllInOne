using AllInOne.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AllInOne.Services
{
    internal class StockDataStore : IDataStore<Item>
    {
        private FirebaseDB db;

        public StockDataStore()
        {
            db = new FirebaseDB();
        }
        public Task<bool>  AddItemAsync(Item item)
        {
            _ = db.AddItems(item.Name, item.Price, item.Description);
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
