using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;
using MediatR;
using ErrorOr;

namespace DialCMS.Application.Commands.CreateContent;

public class CreateContentCommandHandler: IRequestHandler<CreateContentCommand, ErrorOr<Guid>>
{
    private readonly IContentRepository _contentRepository;
    private readonly IContentTypeRepository _contentTypeRepository;
    
    public CreateContentCommandHandler(IContentRepository contentRepository
        , IContentTypeRepository contentTypeRepository)
    {
        _contentRepository = contentRepository;
        _contentTypeRepository = contentTypeRepository;
    }
    
    public Task<ErrorOr<Guid>> Handle(CreateContentCommand request, CancellationToken cancellationToken)
    {
        var contentType = _contentTypeRepository.GetById(request.ContentTypeId);
        if (contentType == null)
            return Task.FromResult<ErrorOr<Guid>>(Error.NotFound( code: "ContentType.NotFound",
                description: "The specified ContentType was not found."));
            
        var content = new Content(contentType);
        _contentRepository.Add(content);

        return Task.FromResult<ErrorOr<Guid>>(content.Id);
    }
}