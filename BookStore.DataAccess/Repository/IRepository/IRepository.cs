using System.Linq.Expressions;

namespace BookStore.DataAccess.Repository.IRepository;

public interface IRepository<T> where T: class
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T?> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
    Task AddAsync(T entity, CancellationToken cancellationToken);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}