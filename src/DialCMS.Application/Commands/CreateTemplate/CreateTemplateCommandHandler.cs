using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;
using DialCMS.Domain.ValueObjects;
using MediatR;
using ErrorOr;
namespace DialCMS.Application.Commands.CreateTemplate;


public class CreateTemplateCommandHandler(ITemplateRepository templateRepository)
    : IRequestHandler<CreateTemplateCommand, ErrorOr<Guid>>
{
    public Task<ErrorOr<Guid>> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        // Mapear TemplateFieldDto para TemplateField
        var fields = request.Template.Fields.Select(f => new TemplateField(f.Name, f.Type, f.ValidationRules)).ToList();

        // Criar o template
        var template = new Template(request.Template.Name, fields);

        // Persistir o template no repositório
        templateRepository.Add(template);

        return Task.FromResult<ErrorOr<Guid>>(template.Id);
    }
}