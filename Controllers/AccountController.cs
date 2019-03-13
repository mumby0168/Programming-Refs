using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Programming_Reference_Website.Models.ViewModels;
using Programming_Reference_Website.Services.Interfaces;

namespace Programming_Reference_Website.Controllers
{
    [Route("api/[controller]/[action]")]    
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Create([FromBody]CreateUserViewModel createUserViewModel)
        {
            return Ok();
        }        

        public IActionResult Login([FromBody]LoginViewModel loginViewModel)
        {
            
            bool successfulLogin = _authenticationService.Login(loginViewModel.Email, loginViewModel.Password, HttpContext);
            if(successfulLogin) return Ok();

            return Unauthorized();     
        }

        public IActionResult Logout()
        {
            return Ok();
        }
    }
}