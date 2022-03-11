using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using AllInOne.Models;
using AllInOne.Services;
using AllInOne.ViewModel;
using Firebase.Database;
using Firebase.Database.Query;
namespace AllInOne.Services
{
    public class FirebaseDB
    {
        FirebaseClient client;
        public FirebaseDB()
        {
            client = new FirebaseClient(ConfigFirebase.FirebaseClient);
        }
        public async Task AddItems(string name, string description, string icon, string price)
        {
            Item item = new Item() { Name = name, Description = description, Icon = icon, Price= price};
            await client
                .Child("Items")
                .PostAsync(item);
        }
        public ObservableCollection<Item> GetItems()
        {
            var itemData = client
                .Child("Items")
                .AsObservable<Item>()
                .AsObservableCollection();
            return itemData;
        }
    }
}
