using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Programming_Reference_Website.Persistance.Repositories.Domain;
using Programming_Reference_Website.Persistance.Repositories.Domain.Interfaces;

namespace Programming_Reference_Website.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(DbContext context)
        {
            _context = context;

            UserRepository = new UserRepository(context);
            TopicRepository = new TopicRepository(context);
        }

        public IUserRepository UserRepository { get; }

        public ITopicRepository TopicRepository { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}