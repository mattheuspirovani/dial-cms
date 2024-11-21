using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;

namespace DialCMS.Infrastructure.Repositories;

public class InMemoryContentTypeRepository: InMemoryRepository<ContentType>, IContentTypeRepository
{
    public ContentType? GetByName(string name)
    {
        return Find(contentType => contentType.Name == name).FirstOrDefault();
    }
}