using DialCMS.Domain.Entities;

namespace DialCMS.Domain.Repositories;

public interface IContentRepository: IRepository<Content>
{
    IEnumerable<Content> GetByStatus(ContentStatus status);
    IEnumerable<Content> GetByContentType(Guid contentTypeId);
}