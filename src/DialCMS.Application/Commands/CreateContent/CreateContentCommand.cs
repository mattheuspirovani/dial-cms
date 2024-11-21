using MediatR;
using ErrorOr;

namespace DialCMS.Application.Commands.CreateContent;

public class CreateContentCommand : IRequest<ErrorOr<Guid>>
{
    public Guid ContentTypeId { get; set; }
}