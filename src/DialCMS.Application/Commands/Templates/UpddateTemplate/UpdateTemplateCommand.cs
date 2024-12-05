using DialCMS.Domain.Entities;
using ErrorOr;
using MediatR;

namespace DialCMS.Application.Commands.Templates.UpddateTemplate;

public record UpdateTemplateCommand(Guid TemplateId, Template Template) : IRequest<ErrorOr<Template>>;