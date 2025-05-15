using System.Linq.Expressions;
using Project.Model;

namespace Project.Repository.Common;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<PagedList<T>> GetFilteredPagedAsync(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        int pageNumber = 1,
        int pageSize = 10);
    Task<T> GetByIdAsync(int id);
    Task<int> InsertAsync(T entity);
    Task<int> UpdateAsync(T entity);
    Task<int> DeleteAsync(int id);
}
