using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Services
{
    public interface IEntityService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> CreateAsync(T t);
        Task<T> UpdateAsync(T t);
        Task RemoveAsync(int id);
    }
}
