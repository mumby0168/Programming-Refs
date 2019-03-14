using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Programming_Reference_Website.Models;

namespace Programming_Reference_Website.Controllers
{
    [Route("api/topics/[action]")]
    public class TopicsController : Controller
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Debug.WriteLine("get" + id);
            return null;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(new List<Topic>
            {
                new Topic{
                    Name = "ASP.NET CORE",
                    Id = 1,
                    Description = "This is the new web tech that this website is written in."
                },
                new Topic{
                    Name = "EF CORE",
                    Id = 2,
                    Description = "This is the new tech that this database is written in."
                }
            });
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Topic topic)
        {
            Debug.WriteLine("add" + topic.Name);
            return null;
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Topic topic)
        {
            Debug.WriteLine("update" + topic.Name);
            return null;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Debug.WriteLine("delete" + id);
            return null;
        }
    }
}