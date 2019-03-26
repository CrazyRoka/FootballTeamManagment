using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Services
{
    public interface IAuthentificationService
    {
        Task<string> Authentificate(string email, string password);
    }
}
