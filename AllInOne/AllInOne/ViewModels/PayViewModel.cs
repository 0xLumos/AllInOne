using AllInOne.Services;
using AllInOne.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AllInOne.ViewModels
{
    public class PayViewModel : BaseViewModel
    {
        private FirebaseDB firebase;

        public string nameoncard;
        public string sortcode;
        public string expirydate;


        public Command SaveCommand { get; }
        public Command CancelCommand { get; }


        public PayViewModel()
        {
            firebase = new FirebaseDB();

            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public async Task AddPurchaseAsync(string nameoncard, string sortcode, string expirydate)
        {
            await firebase.AddPurchace(nameoncard, sortcode, expirydate);
        }
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(nameoncard)
                && !String.IsNullOrWhiteSpace(sortcode)
                && !String.IsNullOrWhiteSpace(expirydate);
        }

        public string NameOnCard
        {
            get => nameoncard;
            set => SetProperty(ref nameoncard, value);
        }
        public string SortCode
        {
            get => sortcode;
            set => SetProperty(ref sortcode, value);
        }

        public string ExpiryDate
        {
            get => expirydate;
            set => SetProperty(ref expirydate, value);
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            // await Shell.Current.GoToAsync("..");
            await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");

        }

        private async void OnSave()
        {
           
            await AddPurchaseAsync(nameoncard, sortcode, expirydate);

            await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
        }
    }
}
