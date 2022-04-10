using Firebase.Database;
using Firebase.Database.Query;
using AllInOne.Views;
using Xamarin.Forms;
using System.Threading.Tasks;

using Firebase;
using AllInOne.Models;
using System.Collections.ObjectModel;

namespace AllInOne.ViewModels
{
    public class LoginViewModel : BaseViewModel
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
        public Command LoginCommand { protected set; get; }
        public Command RegisterButton { protected set; get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterButton = new Command(RegisterLink);
            auth = DependencyService.Get<IAuth>();

        }

        public async void RegisterLink()
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }

        public async void OnLoginClicked()
        {
            // if(user !=null ){
            if (email != null && password != null)
            {
                //if (email == "admin")
                //{
                //    await Shell.Current.GoToAsync($"//{nameof(AdminPage)}");
                //}
                string token = await auth.Login(email, password);
                if (token != string.Empty)
                {
                    await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
                    email = null;
                    password = null;
                }
                else
                {
                    ErrorMessage = "Incorrect email or password !";
                }
            }
            else
            {
                ErrorMessage = "Please specify both fields";
            }


        }
    }
}



