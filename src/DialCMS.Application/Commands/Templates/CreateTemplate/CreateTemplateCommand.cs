using DialCMS.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DialCMS.Application.Commands.Templates.CreateTemplate;

public record CreateTemplateCommand(Template Template) : IRequest<ErrorOr<Guid>>;