using DialCMS.Domain.Entities;
using MediatR;
using ErrorOr;

namespace DialCMS.Application.Queries.GetAllTemplates;

public class GetAllTemplatesQuery: IRequest<ErrorOr<List<Template>>>
{
    
}