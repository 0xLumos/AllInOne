using AllInOne.Views;
using Xamarin.Forms;
namespace AllInOne.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
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
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }
        public async void OnLoginClicked()
        {
            // if(user !=null ){
            if (email != null || password != null)
            {
                if (email != "user" || password != "secret")

                {
                    ErrorMessage = "Wrong email or password!";


                }

                else
                {

                    await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");

                }
              
            }
            else
            {
                ErrorMessage = "Please specify both fields";
            }
               
            
            }
    } }

