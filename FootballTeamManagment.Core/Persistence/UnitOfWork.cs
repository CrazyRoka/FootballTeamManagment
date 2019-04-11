using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Repositories;

namespace FootballTeamManagment.Core.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(
            IRepository<User> userRepository,
            IRepository<Role> roleRepository,
            IRepository<Team> teamRepository,
            IRepository<Snowboard> snowboardRepository,
            IRepository<FootballPlayer> footballPlayerRepository,
            ApplicationDbContext context)
        {
            UserRepository = userRepository;
            RoleRepository = roleRepository;
            TeamRepository = teamRepository;
            SnowboardRepository = snowboardRepository;
            FootballPlayerRepository = footballPlayerRepository;
            _context = context;
        }

        public IRepository<User> UserRepository { get; }

        public IRepository<Role> RoleRepository { get; }

        public IRepository<Team> TeamRepository { get; }

        public IRepository<Snowboard> SnowboardRepository { get; }

        public IRepository<FootballPlayer> FootballPlayerRepository { get; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
