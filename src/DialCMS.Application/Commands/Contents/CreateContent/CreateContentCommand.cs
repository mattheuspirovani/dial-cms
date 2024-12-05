using ErrorOr;
using MediatR;

namespace DialCMS.Application.Commands.Contents.CreateContent;

public class CreateContentCommand : IRequest<ErrorOr<Guid>>
{
    public Guid ContentTypeId { get; set; }
}