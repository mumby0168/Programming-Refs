using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Programming_Reference_Website.Models.ViewModels;

namespace Programming_Reference_Website.Controllers
{
    [Route("api/[controller]")]    
    [Produces("application/json")]
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult Add([FromBody]CreateUserViewModel createUserViewModel)
        {
            Debug.WriteLine(createUserViewModel);

            return CreatedAtAction("Add", "hi");
        }

        [HttpGet("[action]")]
        public IEnumerable<CreateUserViewModel> GetUsers()
        {
            var user = new CreateUserViewModel()
            {
                Email = "billy",
                Password = "billy",
                PasswordReEntered = "billy",
                FriendlyName = "billy"
            };

            return new List<CreateUserViewModel>()
            {
                user
            };
        }
    }
}