using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Programming_Reference_Website.Factories.Interfaces;
using Programming_Reference_Website.Models;
using Programming_Reference_Website.Persistance;
using Programming_Reference_Website.Services.Interfaces;

namespace Programming_Reference_Website.Services
{
    public class AuthenticationService : Programming_Reference_Website.Services.Interfaces.IAuthenticationService
    {
        private readonly IPasswordProtectionService _passwordProtectionService;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public AuthenticationService(IPasswordProtectionService passwordProtectionService, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _passwordProtectionService = passwordProtectionService;
        }

        public async Task<bool> Login(string email, string password, HttpContext context)
        {
            var user = await DoesEmailExists(email);
            if(user != null)
            {
                var result = _passwordProtectionService.Check(password, user.Password, user.Salt);                
                if(result)
                {
                    var claimIdent = new ClaimsIdentity(new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                    }, 
                    CookieAuthenticationDefaults.AuthenticationScheme);

                    await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdent));
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> Register(string email, string password, string friendlyName)
        {            
            if(DoesEmailExists(email) != null)
            {
                var (pword, salt) = _passwordProtectionService.Encrypt(password);
                var user = new User {
                    Password = pword,
                    Salt = salt,
                    Email = email, 
                    FreindlyName = friendlyName
                };

                using(var uow = _unitOfWorkFactory.GetInstance())
                {
                    await uow.UserRepository.AddAysnc(user);
                    await uow.CompleteAsync();
                }

                return true;
            }
            return false;
        }

        private async Task<User> DoesEmailExists(string email)
        {
            using(var uow = _unitOfWorkFactory.GetInstance())
            {
                var user = await uow.UserRepository.SingleOrDefaultAysnc(u => u.Email == email);
                if(user != null) return user;
                return null;
            }
        }
    }
}