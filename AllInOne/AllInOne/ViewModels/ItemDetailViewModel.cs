using AllInOne.Models;
using AllInOne.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AllInOne.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        public Command BuyCommand { protected set; get; }
        public ItemDetailViewModel()
        {
            BuyCommand = new Command(BuyLink);

        }
        public async void BuyLink()
        {
            await Shell.Current.GoToAsync($"//{nameof(PayPage)}");
        }
        private string itemId;
        private string name;
        private string description;
        private string price;
        private string icon;

        public string Id { get; set; }

        

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }
        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }
        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Name = item.Name;
                Description = item.Description;
                Price = item.Price;
                Icon = item.Icon;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }



        }
    }

