using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;
using MediatR;
using ErrorOr;

namespace DialCMS.Application.Queries.GetContentById;

public class GetContentByIdQueryHandler : IRequestHandler<GetContentByIdQuery, ErrorOr<Content>>
{
    private readonly IContentRepository _contentRepository;

    public GetContentByIdQueryHandler(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }

    public Task<ErrorOr<Content>> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
    {
        var content = _contentRepository.GetById(request.Id);
        if (content == null)
        {
            return Task.FromResult<ErrorOr<Content>>(Error.NotFound(
                code: "Content.NotFound",
                description: "The specified Content was not found."
            ));
        }

        return Task.FromResult<ErrorOr<Content>>(content);
    }
}