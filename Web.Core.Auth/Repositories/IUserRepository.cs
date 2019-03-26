using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.Core.Auth.Models;

namespace Web.Core.Auth.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user, ApplicationRole[] roles);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> condition);
        Task<User> FindAsync(Expression<Func<User, bool>> condition);
        void Update(User user);
        void Remove(User user);
    }
}
