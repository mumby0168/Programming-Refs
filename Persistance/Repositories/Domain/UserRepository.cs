using Microsoft.EntityFrameworkCore;
using Programming_Reference_Website.Models;
using Programming_Reference_Website.Persistance.Repositories.Core;
using Programming_Reference_Website.Persistance.Repositories.Domain.Interfaces;

namespace Programming_Reference_Website.Persistance.Repositories.Domain
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}