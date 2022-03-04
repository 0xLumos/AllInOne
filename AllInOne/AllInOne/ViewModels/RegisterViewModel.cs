using AllInOne.Views;
using Xamarin.Forms;
namespace AllInOne.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string errorMessage;
        public string ErrorMessage { get => errorMessage;
            set {
                errorMessage = value;
                OnPropertyChanged();
            }
        }

        public string firstname;

        public string Firstname
        {
            get { return firstname; }
            set
            {
                firstname = value;

            }
        }
        public string lastname;
        public string Lastname
        {
            get { return lastname; }
            set
            {
                lastname = value;

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


        public string cnfrmpswd;

        public string CnfrmPswd
        {
            get { return cnfrmpswd; }
            set
            {
                lastname = value;

            }
        }

    
        public Command RegisterCommand { protected set; get; }
        public Command RegisterButton { protected set; get; }
        public RegisterViewModel()
        {
            RegisterCommand = new Command(OnRegisterClicked);
            RegisterButton = new Command(RegisterLink);
        }
        public async void OnRegisterClicked()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
        public async void RegisterLink()
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPage)}");
        }

    } }

