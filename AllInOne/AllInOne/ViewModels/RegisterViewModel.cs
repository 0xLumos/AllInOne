using AllInOne.Views;
using AllInOne.Models;
using Xamarin.Forms;
using Firebase;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace AllInOne.ViewModels

{
    public class RegisterViewModel : BaseViewModel
    {

        public ObservableCollection<User> Individuals { get; set; } = new ObservableCollection<User>();

        IAuth auth;
        private string errorMessage;
        public string ErrorMessage { get => errorMessage;
            set {
                errorMessage = value;
                OnPropertyChanged();
            }
        }


        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;

            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;

            }
        }




        public Command RegisterCommand { protected set; get; }
        public Command RegisterButton { protected set; get; }
        public RegisterViewModel()
        {
            CancelCommand = new Command(OnCancel);
            RegisterCommand = new Command(OnRegisterClicked);
            auth = DependencyService.Get<IAuth>();
        }
 

        public async void OnRegisterClicked()
        {
            if (Email != null && Password != null)
            {

                if (ValidData.IsValidEmail(Email))
                {
                    if (Password.Length >= 8)
                    {
                        if (ValidData.IsValidPassword(Password))
                        {
                            var user = auth.Signup(email, password);
                            if (user != null)
                            {
                                await App.Current.MainPage.DisplayAlert("Success", "Account created !", "OK");
                                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                            }
                        }
                        else
                        {
                            ErrorMessage = "Password must be at least 8 characters, no more than 12 characters, and must include at least one upper case letter,one lower case letter, and one numeric digit";
                        }

                    }
                    else
                    {
                        ErrorMessage = "Password must be minimumm of 8";
                    }
                }
                else
                {
                    ErrorMessage = "Not a valid Email address";
                }




            }
            else
            {
                ErrorMessage = "User or Password is Empty";
            }


        }


        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }


    }
}

