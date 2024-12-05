using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;
using DialCMS.Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace DialCMS.Application.Commands.Templates.CreateTemplate;


public class CreateTemplateCommandHandler(ITemplateRepository templateRepository)
    : IRequestHandler<CreateTemplateCommand, ErrorOr<Guid>>
{
    public Task<ErrorOr<Guid>> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
    {
        // Persistir o template no repositório
        templateRepository.Add(request.Template);

        return Task.FromResult<ErrorOr<Guid>>(request.Template.Id);
    }
}