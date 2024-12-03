using DialCMS.Domain.Entities;

namespace DialCMS.Domain.Repositories;

public interface ITemplateRepository : IRepository<Template>
{
    Task<List<Template>> GetAllTemplatesAsync();
}