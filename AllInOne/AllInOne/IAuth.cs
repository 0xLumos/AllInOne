using System;
using System.Threading.Tasks;


namespace AllInOne
{
    public interface IAuth
    {
        Task<string> Login(string username, string password);
        Task<string> Signup(string username, string password);
        bool Signout();
    }
}