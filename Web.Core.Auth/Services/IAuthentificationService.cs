using System.Threading.Tasks;

namespace Web.Core.Auth.Services
{
    public interface IAuthentificationService
    {
        Task<string> Authentificate(string email, string password);
    }
}
