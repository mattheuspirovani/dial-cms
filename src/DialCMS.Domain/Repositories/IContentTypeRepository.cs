using DialCMS.Domain.Entities;

namespace DialCMS.Domain.Repositories;

public interface IContentTypeRepository: IRepository<ContentType>
{
    ContentType? GetByName(string name);
}