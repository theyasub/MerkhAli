using System.Linq.Expressions;
using MerkhAli.Data.Contexts;
using MerkhAli.Data.IRepository;
using Microsoft.EntityFrameworkCore;

namespace MerkhAli.Data.Repository;

public class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : class
{
    private MerkhAliDbContext _dbContext;
    private DbSet<TSource> _dbSet;

    public GenericRepository(MerkhAliDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TSource>();
    }


    public IQueryable<TSource> GetAll(Expression<Func<TSource, bool>> expression = null, string include = null, bool isTracking = true)
    {
        IQueryable<TSource> query = expression is null ? _dbSet : _dbSet.Where(expression);

        if (!string.IsNullOrEmpty(include))
            query = query.Include(include);

        if (!isTracking)
            query = query.AsNoTracking();

        return query;
    }

    public async Task<TSource> AddAsync(TSource entity)
    {
        var entry = await _dbSet.AddAsync(entity);

        return entry.Entity;
    }

    public async Task<TSource> GetAsync(Expression<Func<TSource, bool>> expression = null, string include = null)
    {
        return await GetAll(expression, include).FirstOrDefaultAsync();
    }

    public async Task<TSource> UpdateAsync(TSource entity)
    {
        return _dbSet.Update(entity).Entity;
    }

    public async Task DeleteAsync(Expression<Func<TSource, bool>> expression)
    {
        var entity = await GetAsync(expression);
        
        _dbSet.Remove(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}