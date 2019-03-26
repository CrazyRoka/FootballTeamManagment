using System.Linq;
using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using FootballTeamManagment.Core.Security;

namespace FootballTeamManagment.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        public UserService(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> CreateUserAsync(User user, ApplicationRole[] roles)
        {
            var existingUser = await FindByEmailAsync(user.Email);
            if(existingUser != null)
            {
                return null;
            }

            await ConfigureUser(user, roles);

            await _unitOfWork.UserRepository.AddAsync(user);
            await _unitOfWork.SaveAsync();

            user.Password = null;
            return user;
        }

        private async Task ConfigureUser(User user, ApplicationRole[] appRoles)
        {
            user.Password = _passwordHasher.HashPassword(user.Password);

            var roles = await _unitOfWork.RoleRepository
                            .GetAllAsync(r => appRoles.Any(ar => ar.ToString() == r.Name));

            foreach (var role in roles)
            {
                user.UserRoles.Add(new UserRole { RoleId = role.Id });
            }
        }

        private async Task<User> FindByEmailAsync(string email) =>
            await _unitOfWork.UserRepository.FindAsync(u => u.Email == email);
    }
}
