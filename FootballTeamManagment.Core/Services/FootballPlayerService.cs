using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Services
{
    public class FootballPlayerService : IEntityService<FootballPlayer>
    {
        private readonly IUnitOfWork _unitOfWork;
        public FootballPlayerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FootballPlayer> CreateAsync(FootballPlayer player)
        {
            try
            {
                await _unitOfWork.FootballPlayerRepository.AddAsync(player);
                await _unitOfWork.SaveAsync();
            }
            catch(DbUpdateException ex)
            {
                return null;
            }
            return player;
        }

        public async Task<IEnumerable<FootballPlayer>> GetAllAsync() =>
            await _unitOfWork.FootballPlayerRepository.GetAllAsync();

        public async Task<FootballPlayer> GetAsync(int id) =>
            await _unitOfWork.FootballPlayerRepository.FindAsync(p => p.Id == id);

        public async Task RemoveAsync(int id)
        {
            var player = await _unitOfWork.FootballPlayerRepository.FindAsync(p => p.Id == id);
            if(player != null)
            {
                _unitOfWork.FootballPlayerRepository.Remove(player);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<FootballPlayer> UpdateAsync(FootballPlayer player)
        {
            try
            {
                _unitOfWork.FootballPlayerRepository.Update(player);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateException ex)
            {
                return null;
            }
            return player;
        }
    }
}
