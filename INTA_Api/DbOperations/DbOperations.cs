using INTA_Api.EntitySettings;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace INTA_Api.DbOperations;

public class DbOperations<T> : IDbOperations<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public DbOperations(AppDbContext dbContext)
    {
        _context = dbContext;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> Add(T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> Delete(T entity)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> GetByFilterSingle(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.Where(filter).FirstOrDefaultAsync();
    }

    public async Task<T> Update(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<T>> GetAllWithLanguage(string lang)
    {
        return await _dbSet
            .Where(e => EF.Property<string>(e, "Language") == lang)
            .ToListAsync();
    }

    public async Task<bool> IsRecorded(Expression<Func<T, bool>> filter)
    {
        return await _dbSet.AnyAsync(filter);
    }
}
