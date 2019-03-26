using System.Threading.Tasks;
using FootballTeamManagment.Core.Repositories;

namespace FootballTeamManagment.Core.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
