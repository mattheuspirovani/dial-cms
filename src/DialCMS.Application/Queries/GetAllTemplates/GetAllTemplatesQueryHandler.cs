using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;
using MediatR;
using ErrorOr;

namespace DialCMS.Application.Queries.GetAllTemplates;

public class GetAllTemplatesQueryHandler(ITemplateRepository templateRepository)
    : IRequestHandler<GetAllTemplatesQuery, ErrorOr<List<Template>>>
{
    public async Task<ErrorOr<List<Template>>> Handle(GetAllTemplatesQuery request, CancellationToken cancellationToken)
    {
        var templates = await templateRepository.GetAllTemplatesAsync();

        return templates;
    }
}