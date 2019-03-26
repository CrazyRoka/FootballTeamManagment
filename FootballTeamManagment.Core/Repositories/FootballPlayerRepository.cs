using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace FootballTeamManagment.Core.Repositories
{
    public class FootballPlayerRepository : AbstractRepository<FootballPlayer>
    {
        public FootballPlayerRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<FootballPlayer> FindAsync(Expression<Func<FootballPlayer, bool>> condition) =>
            await TeamsWithPlayers.SingleOrDefaultAsync(condition);

        public override async Task<IEnumerable<FootballPlayer>> GetAllAsync() =>
            await TeamsWithPlayers.ToListAsync();

        public override async Task<IEnumerable<FootballPlayer>> GetAllAsync(Expression<Func<FootballPlayer, bool>> condition) =>
            await TeamsWithPlayers.Where(condition).ToListAsync();

        private IIncludableQueryable<FootballPlayer, Team> TeamsWithPlayers =>
            _context.FootballPlayers.Include(p => p.Team);
    }
}
