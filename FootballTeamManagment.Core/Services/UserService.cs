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

            user.Password = _passwordHasher.HashPassword(user.Password);

            await _unitOfWork.UserRepository.AddAsync(user, roles);
            await _unitOfWork.SaveAsync();

            user.Password = null;
            return user;
        }

        private async Task<User> FindByEmailAsync(string email) =>
            await _unitOfWork.UserRepository.FindAsync(u => u.Email == email);
    }
}
