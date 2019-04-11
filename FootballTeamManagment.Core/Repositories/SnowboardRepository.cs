using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Repositories
{
    public class SnowboardRepository : BaseRepository<Snowboard>
    {
        public SnowboardRepository(ApplicationDbContext context) : base(context)
        {
        }

        public override async Task<Snowboard> FindAsync(Expression<Func<Snowboard, bool>> condition) =>
            await _context.Snowboards.SingleOrDefaultAsync(condition);

        public override async Task<IEnumerable<Snowboard>> GetAllAsync() =>
            await _context.Snowboards.ToListAsync();

        public override async Task<IEnumerable<Snowboard>> GetAllAsync(Expression<Func<Snowboard, bool>> condition) =>
            await _context.Snowboards.Where(condition).ToListAsync();
    }
}
