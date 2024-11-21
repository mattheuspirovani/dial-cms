using DialCMS.Application.Dtos;
using DialCMS.Domain.Entities;
using MediatR;
using ErrorOr;

namespace DialCMS.Application.Commands.CreateContentType;

public class CreateContentTypeCommand : IRequest<ErrorOr<Guid>>
{
    public string Name { get; set; }
    public List<FieldDto> Fields { get; set; } = new();
}