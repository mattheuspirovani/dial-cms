using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;
using MediatR;
using ErrorOr;

namespace DialCMS.Application.Commands.Templates.UpddateTemplate;

public class UpdateTemplateCommandHandler(ITemplateRepository templateRepository) : IRequestHandler<UpdateTemplateCommand, ErrorOr<Template>>
{
    public async Task<ErrorOr<Template>> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
    {
        var template = await templateRepository.GetById(request.TemplateId);
        
        if (template == null)
            return Error.NotFound(description:"Template not found");
        
        template.Update(request.Template.Name, request.Template.Fields, request.Template.Status);
        templateRepository.Update(template);

        return template;
    }
}