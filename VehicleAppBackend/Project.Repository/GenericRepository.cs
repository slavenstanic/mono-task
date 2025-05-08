using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Project.DAL;
using Project.Model;
using Project.Repository.Common;

namespace Project.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ProjectDbContext _context;
    
    protected readonly DbSet<T> _dbSet;
    
    public GenericRepository(ProjectDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();
    
    public async Task<PagedList<T>> GetPagedAsync(int pageNumber, int pageSize)
    {
        var totalCount = await _dbSet.CountAsync();

        var items = await _dbSet
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedList<T>(items, totalCount, pageNumber, pageSize);
    }
    
    public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<int> InsertAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> UpdateAsync(T entity)
    {
        _dbSet.Attach(entity);
        _context.Entry(entity).State = EntityState.Modified;
        return await _context.SaveChangesAsync();
    }
    
    public async Task<int> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return 0;
        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync();
    }
    
    public async Task<List<T>> GetFilteredAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
    )
    {
        IQueryable<T> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return await query.ToListAsync();
    }
}
