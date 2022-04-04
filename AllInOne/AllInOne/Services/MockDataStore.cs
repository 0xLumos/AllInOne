using AllInOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllInOne.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "Chair ", Description="This is a chair.", Price= "99.99",Icon= "chair.png",IconTwo = "chair2.png", IconThree = "chair3.png"},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Sofa", Description="This is a chair", Price= "123", Icon="sofa.png" },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Bed", Description="This is a chair" , Price= "123",Icon="bed.png"},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Lamp", Description="This is a chair" , Price= "123",Icon="lamp.png"},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Table", Description="This is a chair",Price= "123", Icon="https://firebasestorage.googleapis.com/v0/b/allinone-342601.appspot.com/o/Images%2FIMG_20220323_061733.jpg?alt=media&token=ec2e4267-606d-4027-a665-193b4ebc7438"}
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}