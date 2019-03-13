using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Programming_Reference_Website.Services.Interfaces;

namespace Programming_Reference_Website.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IPasswordProtectionService _passwordProtectionService;

        public AuthenticationService(IPasswordProtectionService passwordProtectionService)
        {
            _passwordProtectionService = passwordProtectionService;
        }

        public bool Login(string email, string password, HttpContext context)
        {
            return true;
        }

        public bool Register(string email, string password, string friendlyName)
        {
            return true;   
        }
    }
}