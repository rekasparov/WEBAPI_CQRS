using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSI.Repository.Abstract
{
    public interface IBaseRepository<T>
        where T : class, new()
    {
        IQueryable<T> Select(Expression<Func<T, bool>>? predicate = null);
        Task<int> InsertAsync(T entity, CancellationToken cancellationToken);
        Task<int> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task<int> DeleteAsync(T entity, CancellationToken cancellationToken);
    }
}
