using System.Threading.Tasks;
using Web.Core.Auth.Repositories;

namespace Web.Core.Auth.Persistence
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        Task SaveAsync();
    }
}
