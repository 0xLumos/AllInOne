using AllInOne.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AllInOne.ViewModels
{
    public class NewItemViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private string icon;
        private string price;

        public NewItemViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description)
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

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
