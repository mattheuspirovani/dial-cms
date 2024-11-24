using DialCMS.Domain.Entities;
using MediatR;
using ErrorOr;

namespace DialCMS.Application.Queries.GetContentById;

public class GetContentByIdQuery : IRequest<ErrorOr<Content>>
{
    public Guid Id { get; set; }
}