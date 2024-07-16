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

        public async Task<int> DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            var effectedRowCount = 0;
            var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                _dbContext.Remove(entity);

                if (transaction != null)
                    await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                if (transaction != null)
                    await transaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                if (_dbContext.ChangeTracker.HasChanges())
                    effectedRowCount = await _dbContext.SaveChangesAsync(cancellationToken);

                if (transaction != null)
                    await transaction.DisposeAsync();
            }
            return effectedRowCount;
        }

        public async Task<int> InsertAsync(T entity, CancellationToken cancellationToken)
        {
            var effectedRowCount = 0;
            var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await _dbContext.AddAsync(entity, cancellationToken);

                if (transaction != null)
                    await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                if (transaction != null)
                    await transaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                if (_dbContext.ChangeTracker.HasChanges())
                    effectedRowCount = await _dbContext.SaveChangesAsync(cancellationToken);

                if (transaction != null)
                    await transaction.DisposeAsync();
            }
            return effectedRowCount;
        }

        public IQueryable<T> Select(Expression<Func<T, bool>>? predicate = null)
        {
            if (predicate == null)
                return _dbContext.Set<T>().AsQueryable();
            else
                return _dbContext.Set<T>().Where(predicate);
        }

        public async Task<int> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            var effectedRowCount = 0;
            var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                _dbContext.Update(entity);

                if (transaction != null)
                    await transaction.CommitAsync(cancellationToken);
            }
            catch
            {
                if (transaction != null)
                    await transaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                if (_dbContext.ChangeTracker.HasChanges())
                    effectedRowCount = await _dbContext.SaveChangesAsync(cancellationToken);

                if (transaction != null)
                    await transaction.DisposeAsync();
            }
            return effectedRowCount;
        }
    }
}
