using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Web.Core.Auth.Models;
using Web.Core.Auth.Persistence;

namespace Web.Core.Auth.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user, ApplicationRole[] appRoles)
        {
            var roles = await _context.Roles.Where(r =>
                appRoles.Any(ar => ar.ToString() == r.Name)).ToListAsync();

            foreach(var role in roles)
            {
                user.UserRoles.Add(new UserRole { RoleId = role.Id });
            }

            _context.Users.Add(user);
        }

        public async Task<User> FindAsync(Expression<Func<User, bool>> condition) =>
            await UsersWithRoles.SingleOrDefaultAsync(condition);

        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> condition) =>
            await UsersWithRoles.Where(condition).ToListAsync();

        public Task<IEnumerable<User>> GetAllAsync() => GetAllAsync((_) => true);

        public void Remove(User user) => _context.Users.Remove(user);

        public void Update(User user) => _context.Users.Update(user);

        private IIncludableQueryable<User, Role> UsersWithRoles =>
            _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role);
    }
}
