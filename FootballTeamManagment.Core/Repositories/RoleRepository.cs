using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballTeamManagment.Core.Repositories
{
    public class RoleRepository : AbstractRepository<Role>
    {
        public RoleRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Role> FindAsync(Expression<Func<Role, bool>> condition) =>
            await _context.Roles.Where(condition).SingleOrDefaultAsync();

        public override async Task<IEnumerable<Role>> GetAllAsync() =>
            await _context.Roles.ToListAsync();

        public override async Task<IEnumerable<Role>> GetAllAsync(Expression<Func<Role, bool>> condition) =>
            await _context.Roles.Where(condition).ToListAsync();
    }
}
