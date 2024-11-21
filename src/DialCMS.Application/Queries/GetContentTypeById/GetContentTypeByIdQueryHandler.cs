using MediatR;
using ErrorOr;
using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;

namespace DialCMS.Application.Queries.GetContentTypeById;

public class GetContentTypeByIdQueryHandler : IRequestHandler<GetContentTypeByIdQuery, ErrorOr<ContentType>>
{
    private readonly IContentTypeRepository _contentTypeRepository;

    public GetContentTypeByIdQueryHandler(IContentTypeRepository contentTypeRepository)
    {
        _contentTypeRepository = contentTypeRepository;
    }

    public Task<ErrorOr<ContentType>> Handle(GetContentTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var contentType = _contentTypeRepository.GetById(request.Id);

        if (contentType == null)
        {
            return Task.FromResult<ErrorOr<ContentType>>(Error.NotFound(
                code: "ContentType.NotFound",
                description: "The specified ContentType was not found."
            ));
        }

        return Task.FromResult<ErrorOr<ContentType>>(contentType);
    }
}