using MediatR;
using ErrorOr;
using DialCMS.Domain.Entities;

namespace DialCMS.Application.Queries.GetContentTypeById;

public class GetContentTypeByIdQuery : IRequest<ErrorOr<ContentType>>
{
    public Guid Id { get; set; }
}