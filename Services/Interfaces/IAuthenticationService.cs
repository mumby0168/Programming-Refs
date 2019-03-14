using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Programming_Reference_Website.Models.ViewModels;

namespace Programming_Reference_Website.Services.Interfaces
{
    public interface IAuthenticationService
    {
         Task<bool> Login(string email, string password, HttpContext context);

         Task<bool> Register(string email, string password, string friendlyName);         
    }
}