using System.Linq.Expressions;
using _.Models;

namespace _.Repositories;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
    Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector, bool ascending = true);

}
