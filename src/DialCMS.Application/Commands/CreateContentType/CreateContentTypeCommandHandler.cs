using DialCMS.Application.Extensions;
using MediatR;
using ErrorOr;
using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;

namespace DialCMS.Application.Commands.CreateContentType;

public class CreateContentTypeCommandHandler : IRequestHandler<CreateContentTypeCommand, ErrorOr<Guid>>
{
    private readonly IContentTypeRepository _contentTypeRepository;

    public CreateContentTypeCommandHandler(IContentTypeRepository contentTypeRepository)
    {
        _contentTypeRepository = contentTypeRepository;
    }

    public Task<ErrorOr<Guid>> Handle(CreateContentTypeCommand request, CancellationToken cancellationToken)
    {
        var contentType = new ContentType(request.Name);
        var fields = request.Fields.ToFields();
        foreach (var field in fields)
        {
            contentType.AddField(field);
        }

        _contentTypeRepository.Add(contentType);

        return Task.FromResult<ErrorOr<Guid>>(contentType.Id);
    }
}