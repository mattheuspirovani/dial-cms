using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;

namespace DialCMS.Infrastructure.Repositories;

public class InMemoryContentRepository: InMemoryRepository<Content>, IContentRepository
{
    public IEnumerable<Content> GetByStatus(ContentStatus status)
    {
        return Find(content => content.Status == status);
    }

    public IEnumerable<Content> GetByContentType(Guid contentTypeId)
    {
        return Find(content => content.ContentTypeId == contentTypeId);
    }
}