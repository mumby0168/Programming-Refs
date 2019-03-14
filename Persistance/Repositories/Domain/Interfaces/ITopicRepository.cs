using Programming_Reference_Website.Models;
using Programming_Reference_Website.Persistance.Repositories.Core.Interfaces;

namespace Programming_Reference_Website.Persistance.Repositories.Domain.Interfaces
{
    public interface ITopicRepository : IRepository<Topic>, IRepositoryAsync<Topic>
    {
         
    }
}