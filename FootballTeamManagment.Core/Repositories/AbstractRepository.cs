using FootballTeamManagment.Core.Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FootballTeamManagment.Core.Repositories
{
    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        public AbstractRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T t) => await _context.AddAsync(t);

        public void Remove(T t) => _context.Remove(t);

        public void Update(T t) => _context.Update(t);

        public abstract Task<T> FindAsync(Expression<Func<T, bool>> condition);

        public abstract Task<IEnumerable<T>> GetAllAsync();

        public abstract Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> condition);
    }
}
