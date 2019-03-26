using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Repositories
{
    public class TeamRepository : AbstractRepository<Team>
    {
        public TeamRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Team> FindAsync(Expression<Func<Team, bool>> condition) =>
            await TeamsWithPlayers.SingleOrDefaultAsync(condition);

        public override async Task<IEnumerable<Team>> GetAllAsync() =>
            await TeamsWithPlayers.ToListAsync();

        public override async Task<IEnumerable<Team>> GetAllAsync(Expression<Func<Team, bool>> condition) =>
            await TeamsWithPlayers.Where(condition).ToListAsync();

        private IIncludableQueryable<Team, ICollection<FootballPlayer>> TeamsWithPlayers =>
            _context.Teams.Include(t => t.FootballPlayers);
    }
}
