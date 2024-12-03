using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;

namespace DialCMS.Infrastructure.Repositories;

public class InMemoryTemplateRepository : InMemoryRepository<Template>, ITemplateRepository
{
    public Task<List<Template>> GetAllTemplatesAsync()
    {
        var templates = GetAll().ToList();
        return Task.FromResult(templates); 
    }
}