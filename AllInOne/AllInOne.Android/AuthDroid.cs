using AllInOne.Droid;
using System;
using Xamarin.Forms;
using Firebase.Auth;
using System.Threading.Tasks;
using Android.Gms.Extensions;

[assembly: Dependency(typeof(AuthDroid))]
namespace AllInOne.Droid
{
    internal class AuthDroid : IAuth
    {
        public async Task<string> Login(string username, string password)
        {
            try
            {
                var User = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(username, password);
                var token = await User.User.GetIdToken(false);
                return (string)token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return String.Empty;
            }
            catch (FirebaseAuthInvalidCredentialsException e)
            {
                e.PrintStackTrace();
                return String.Empty;
            }
        }

        public bool Signout()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.Instance.SignOut();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<string> Signup(string username, string password)
        {
            try
            {
                var newUser = await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(username, password);
                var token = await newUser.User.GetIdToken(false);
                return (string)token;
            }
            catch (FirebaseAuthInvalidUserException e)
            {
                e.PrintStackTrace();
                return String.Empty;
            }
        }
    }
}