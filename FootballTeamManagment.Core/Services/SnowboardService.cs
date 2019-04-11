using FootballTeamManagment.Core.Models;
using FootballTeamManagment.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Services
{
    public class SnowboardService : IEntityService<Snowboard>
    {
        private IUnitOfWork _unitOfWork;
        public SnowboardService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Snowboard> CreateAsync(Snowboard snowboard)
        {
            try
            {
                await _unitOfWork.SnowboardRepository.AddAsync(snowboard);
                await _unitOfWork.SaveAsync();
            }
            catch
            {
                return null;
            }
            return snowboard;
        }

        public Task<IEnumerable<Snowboard>> GetAllAsync() => _unitOfWork.SnowboardRepository.GetAllAsync();

        public Task<Snowboard> GetAsync(int id) => _unitOfWork.SnowboardRepository.FindAsync(s => s.Id == id);

        public async Task RemoveAsync(int id)
        {
            var snowboard = await GetAsync(id);
            if(snowboard != null)
            {
                _unitOfWork.SnowboardRepository.Remove(snowboard);
                await _unitOfWork.SaveAsync();
            }
        }

        public async Task<Snowboard> UpdateAsync(Snowboard snowboard)
        {
            try
            {
                _unitOfWork.SnowboardRepository.Update(snowboard);
                await _unitOfWork.SaveAsync();
            }
            catch
            {
                return null;
            }
            return snowboard;
        }
    }
}
