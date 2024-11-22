using System.Linq.Expressions;
using _.Models;
using Microsoft.EntityFrameworkCore;
namespace _.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly MyDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(MyDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
    public async Task<IEnumerable<T>> Where(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.Where(predicate).ToListAsync();
    }
    public async Task<IEnumerable<T>> OrderBy<TKey>(
    Expression<Func<T, TKey>> keySelector, bool ascending = true)
{
    if (ascending)
    {
        return await _dbSet.OrderBy(keySelector).ToListAsync();
    }
    else
    {
        return await _dbSet.OrderByDescending(keySelector).ToListAsync();
    }
}

    
}
