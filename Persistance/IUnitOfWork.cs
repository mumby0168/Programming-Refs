using System;
using System.Threading.Tasks;
using Programming_Reference_Website.Persistance.Repositories.Domain.Interfaces;

namespace Programming_Reference_Website.Persistance
{
    public interface IUnitOfWork :  IDisposable
    {
         IUserRepository UserRepository { get; }

         ITopicRepository TopicRepository { get; }

         int Complete();

         Task<int> CompleteAsync();
    }
}