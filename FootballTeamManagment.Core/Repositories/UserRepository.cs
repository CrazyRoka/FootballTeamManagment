using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;

namespace FootballTeamManagment.Core.Repositories
{
    public class UserRepository : AbstractRepository<User>
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<User> FindAsync(Expression<Func<User, bool>> condition) =>
            await UsersWithRoles.SingleOrDefaultAsync(condition);

        public override async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> condition) =>
            await UsersWithRoles.Where(condition).ToListAsync();

        public override async Task<IEnumerable<User>> GetAllAsync() =>
            await UsersWithRoles.ToListAsync();

        private IIncludableQueryable<User, Role> UsersWithRoles =>
            _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role);
    }
}
