using System.Linq.Expressions;

namespace DialCMS.Domain.Repositories;

public interface IRepository<T> where T : class
{
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    Task<T?> GetById(Guid id);
    IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
}