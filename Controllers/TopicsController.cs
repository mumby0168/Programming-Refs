using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Programming_Reference_Website.Factories.Interfaces;
using Programming_Reference_Website.Models;

namespace Programming_Reference_Website.Controllers
{
    [Route("api/topics/[action]")]
    public class TopicsController : Controller
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public TopicsController(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             using(var uow = _unitOfWorkFactory.GetInstance())
            {
                var topic = await uow.TopicRepository.GetAsync(id);                
                // TODO: Possibly think if null different response.
                return Ok(topic);
            }     
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            using(var uow = _unitOfWorkFactory.GetInstance())
            {
                var topics = await uow.TopicRepository.GetAllAysnc();
                return Ok(topics);
            }                    
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Topic topic)
        {
            using(var uow = _unitOfWorkFactory.GetInstance())
            {
                await uow.TopicRepository.AddAysnc(topic);
                
                await uow.CompleteAsync();
                
                return Ok(true);
            }     
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Topic topic)
        {
            using(var uow = _unitOfWorkFactory.GetInstance())
            {
                var topicFromDb = await uow.TopicRepository.GetAsync(topic.Id);

                //TODO: Implement AutoMapper<F, T>
                topicFromDb.Name = topic.Name;
                topicFromDb.Description = topic.Description;
                topicFromDb.TopicLanguages = topic.TopicLanguages;
                topicFromDb.WebResources = topic.WebResources;                
                
                await uow.CompleteAsync();
                
                return Ok(true);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using(var uow = _unitOfWorkFactory.GetInstance())
            {
                var topic = await uow.TopicRepository.GetAsync(id);
                
                await uow.TopicRepository.RemoveAysnc(topic);
                
                await uow.CompleteAsync();
                
                return Ok(true);
            }
        }
    }
}