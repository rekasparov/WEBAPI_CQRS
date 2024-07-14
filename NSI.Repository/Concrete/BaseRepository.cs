using Microsoft.EntityFrameworkCore;
using NSI.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Repository.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, new()
    {
        private readonly DbContext _dbContext;

        protected BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
        }

        public async Task InsertAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
        }

        public IQueryable<T> Select(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
                return _dbContext.Set<T>().AsQueryable();
            else
                return _dbContext.Set<T>().Where(predicate);
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }
    }
}
