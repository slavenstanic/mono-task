using System.Linq.Expressions;
using Project.Model;

namespace Project.Repository.Common;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<PagedList<T>> GetPagedAsync(int pageNumber, int pageSize);
    Task<T> GetByIdAsync(int id);
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
    Task<List<T>> GetFilteredAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null
    );
}
