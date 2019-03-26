using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;

namespace FootballTeamManagment.Core.Services
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user, ApplicationRole[] roles);
        Task<bool> UpdatePasswordAsync(string email, string oldPassword, string newPassword);
    }
}
