using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Programming_Reference_Website.Models.ViewModels;
using Programming_Reference_Website.Services.Interfaces;

namespace Programming_Reference_Website.Controllers
{
    [Route("api/[controller]/[action]")]    
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly Services.Interfaces.IAuthenticationService _authenticationService;

        public AccountController(Services.Interfaces.IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateUserViewModel createUserViewModel)
        {
            if(createUserViewModel.Password == createUserViewModel.PasswordReEntered)
            {
                var result = await _authenticationService.Register(createUserViewModel.Email, createUserViewModel.Password, createUserViewModel.FriendlyName);
                if(result)
                {
                    return Ok("nice one!");
                }
            }

            return BadRequest();
        }        


        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel loginViewModel)
        {            
            bool successfulLogin = await _authenticationService.Login(loginViewModel.Email, loginViewModel.Password, HttpContext);
            if(successfulLogin) return Ok(true);

            return Unauthorized();     
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok(true);
        }
    }
}