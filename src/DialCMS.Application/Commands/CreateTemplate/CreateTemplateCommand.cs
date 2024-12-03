using DialCMS.Domain.Entities;
using MediatR;
using ErrorOr;

namespace DialCMS.Application.Commands.CreateTemplate;

public record CreateTemplateCommand(Template Template) : IRequest<ErrorOr<Guid>>;