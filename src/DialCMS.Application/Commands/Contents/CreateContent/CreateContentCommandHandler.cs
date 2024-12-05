using DialCMS.Domain.Repositories;
using ErrorOr;
using MediatR;

namespace DialCMS.Application.Commands.Contents.CreateContent;

public class CreateContentCommandHandler: IRequestHandler<CreateContentCommand, ErrorOr<Guid>>
{
    private readonly IContentRepository _contentRepository;
    
    public CreateContentCommandHandler(IContentRepository contentRepository)
    {
        _contentRepository = contentRepository;
    }
    
    public Task<ErrorOr<Guid>> Handle(CreateContentCommand request, CancellationToken cancellationToken)
    {
        //var content = new Content();
        //_contentRepository.Add(content);

        //return Task.FromResult<ErrorOr<Guid>>(content.Id);
        return Task.FromResult<ErrorOr<Guid>>(Guid.NewGuid());
    }
}