using FootballTeamManagment.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Services
{
    public interface ITeamService
    {
        Task<IEnumerable<Team>> GetAllAsync();
        Task<Team> CreateAsync(Team team);
        Task<Team> UpdateAsync(Team team);
        Task<Team> GetAsync(int id);
        Task RemoveAsync(int id);
    }
}
