//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Foundation;
//using UIKit;
//using Xamarin.Forms;
//using Firebase.Auth;

//[assembly: Dependency(typeof(AuthIOS))]
//namespace AllInOne.iOS
//{

//    namespace AllInOne.Droid
//    {
//        internal class AuthDroid : IAuth
//        {
//            public async Task<string> Login(string username, string password)
//            {
//                try
//                {
//                    var User = await Firebase.Auth.FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(username, password);
//                    var token = await User.User.GetIdToken(false);
//                    return (string)token;
//                }
//                catch (FirebaseAuthInvalidUserException e)
//                {
//                    e.PrintStackTrace();
//                    return String.Empty;
//                }
//                catch (FirebaseAuthInvalidCredentialsException e)
//                {
//                    e.PrintStackTrace();
//                    return String.Empty;
//                }
//            }

//            public bool Signout()
//            {
//                try
//                {
//                    Firebase.Auth.FirebaseAuth.Instance.SignOut();
//                    return true;
//                }
//                catch (Exception e)
//                {
//                    return false;
//                }
//            }

//            public async Task<string> Signup(string username, string password)
//            {
//                try
//                {
//                    var newUser = await Firebase.Auth.FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(username, password);
//                    var token = await newUser.User.GetIdToken(false);
//                    return (string)token;
//                }
//                catch (FirebaseAuthInvalidUserException e)
//                {
//                    e.PrintStackTrace();
//                    return String.Empty;
//                }
//            }

//            Task<string> IAuth.Login(string username, string password)
//            {
//                throw new NotImplementedException();
//            }

//            bool IAuth.Signout()
//            {
//                throw new NotImplementedException();
//            }

//            Task<string> IAuth.Signup(string username, string password)
//            {
//                throw new NotImplementedException();
//            }
//        }
//    }
//}