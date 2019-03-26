using System.Threading.Tasks;
using FootballTeamManagment.Core.Repositories;

namespace FootballTeamManagment.Core.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(IUserRepository userRepository, ApplicationDbContext context)
        {
            UserRepository = userRepository;
            _context = context;
        }

        public IUserRepository UserRepository { get; }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
