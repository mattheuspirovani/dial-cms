using DialCMS.Domain.Entities;
using DialCMS.Domain.Repositories;
using MediatR;
using ErrorOr;

namespace DialCMS.Application.Queries.GetContentById;

public class GetContentByIdQueryHandler(IContentRepository contentRepository)
    : IRequestHandler<GetContentByIdQuery, ErrorOr<Content>>
{
    public async Task<ErrorOr<Content>> Handle(GetContentByIdQuery request, CancellationToken cancellationToken)
    {
        var content = await contentRepository.GetById(request.Id);
        if (content == null)
        {
            return Error.NotFound(
                code: "Content.NotFound",
                description: "The specified Content was not found."
            );
        }

        return content;
    }
}