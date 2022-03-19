using AllInOne.Models;
using AllInOne.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AllInOne.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        public string name;
        public string description;
        public string icon;
        public string price;

        private FirebaseDB firebase;

        public Command AddItemCommand { get; }

        private ObservableCollection<Item> _items = new ObservableCollection<Item>();

        public NewItemViewModel()
        {
            firebase = new FirebaseDB();
            _items = firebase.GetItems(); 

            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            AddItemCommand= new Command(async () => await AddItemAsync(name, description, icon, price));
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public async Task AddItemAsync(string name, string description, string icon, string price)
        {
            await firebase.AddItems(name, description, icon, price);
        }
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description)
                && !String.IsNullOrWhiteSpace(icon)
                && !String.IsNullOrWhiteSpace(price);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Icon
        {
            get => icon;
            set => SetProperty(ref icon, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string Price
        {
            get => price;
            set => SetProperty(ref price, value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Item newItem = new Item()
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                Description = Description,
                Price = price
            };

            await DataStore.AddItemAsync(newItem);
            await AddItemAsync(name, description, icon, price); ;
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
