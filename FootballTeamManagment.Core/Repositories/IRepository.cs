using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T t);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition);
        Task<T> FindAsync(Expression<Func<T, bool>> condition);
        void Update(T t);
        void Remove(T t);
    }
}
