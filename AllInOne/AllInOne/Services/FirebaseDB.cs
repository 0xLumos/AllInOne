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
using Firebase.Storage;

namespace AllInOne.Services
{
    public class FirebaseDB
    {
        FirebaseClient client;
        public FirebaseDB()
        {
            client = new FirebaseClient(ConfigFirebase.FirebaseClient);
        }
        public async Task AddItems(string name, string description, string price)
        {
            // Youtube tutorial:https://www.youtube.com/watch?v=IsbhleYMpsw&t=798s
            // Upload images to storage
            var photo = await Xamarin.Essentials.MediaPicker.PickPhotoAsync();

            if (photo == null)
                return;

            var task = new FirebaseStorage("allinone-342601.appspot.com",
                new FirebaseStorageOptions
                {
                    ThrowOnCancel = true
                })
                // Firebase node name 
                .Child("Images")
                .Child(photo.FileName)
                .PutAsync(await photo.OpenReadAsync());
            //Youtube tutorial https://www.youtube.com/watch?v=KzDIeI8rJNI&t=260s
            // CRUD Operations
            Item item = new Item() { Name = name, Description = description, Price = price };
            
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