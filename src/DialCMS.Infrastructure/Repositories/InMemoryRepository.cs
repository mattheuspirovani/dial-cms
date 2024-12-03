using System.Linq.Expressions;
using DialCMS.Domain.Repositories;

namespace DialCMS.Infrastructure.Repositories;

public class InMemoryRepository<T> : IRepository<T> where T : class
{
    private readonly List<T> _storage = new();

    public void Add(T entity) => _storage.Add(entity);

    public void Update(T entity)
    {
        if (!_storage.Contains(entity))
            throw new InvalidOperationException("Entity not found in repository.");
    }

    public void Remove(T entity) => _storage.Remove(entity);

    public T? GetById(Guid id)
    {
        var property = typeof(T).GetProperty("Id");
        if (property == null)
            throw new InvalidOperationException("Entity does not have an Id property.");

        return _storage.FirstOrDefault(e => (Guid)property.GetValue(e, null)! == id);
    }
    
    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _storage.AsQueryable().Where(predicate).ToList();
    }
    
    public IEnumerable<T> GetAll()
    {
        return _storage.ToList();
    }
}