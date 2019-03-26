using System.Collections.Generic;
using System.Threading.Tasks;
using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballTeamManagment.Core.Services
{
    public class TeamService : ITeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TeamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Team> CreateAsync(Team team)
        {
            await _unitOfWork.TeamRepository.AddAsync(team);
            await _unitOfWork.SaveAsync();
            return team;
        }

        public async Task<Team> GetAsync(int id)
        {
            Team team = await _unitOfWork.TeamRepository.FindAsync(t => t.Id == id);
            return team;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _unitOfWork.TeamRepository.GetAllAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var team = await _unitOfWork.TeamRepository.FindAsync(t => t.Id == id);
            if (team != null)
            {
                _unitOfWork.TeamRepository.Remove(team);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<Team> UpdateAsync(Team team)
        {
            try
            {
                _unitOfWork.TeamRepository.Update(team);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
            return team;
        }
    }
}
