using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Repositories;

namespace FootballTeamManagment.Core.Persistence
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<Team> TeamRepository { get; }
        IRepository<FootballPlayer> FootballPlayerRepository { get; }
        Task SaveAsync();
    }
}
