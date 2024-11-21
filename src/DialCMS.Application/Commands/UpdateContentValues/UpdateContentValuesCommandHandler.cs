using DialCMS.Application.Services;
using MediatR;
using ErrorOr;
using DialCMS.Domain.Repositories;
using DialCMS.Domain.Entities;

namespace DialCMS.Application.Commands.UpdateContentValues;

public class UpdateContentValuesCommandHandler : IRequestHandler<UpdateContentValuesCommand, ErrorOr<Unit>>
{
    private readonly IContentRepository _contentRepository;
    private readonly ContentValueUpdater _valueUpdater;

    public UpdateContentValuesCommandHandler(
        IContentRepository contentRepository, ContentValueUpdater valueUpdater)
    {
        _contentRepository = contentRepository;
        _valueUpdater = valueUpdater;
    }

    public Task<ErrorOr<Unit>> Handle(UpdateContentValuesCommand request, CancellationToken cancellationToken)
    {
        var content = _contentRepository.GetById(request.ContentId);
        if (content == null)
        {
            return Task.FromResult<ErrorOr<Unit>>(Error.NotFound(
                code: "Content.NotFound",
                description: "The specified Content was not found."
            ));
        }
        
        try
        {
            _valueUpdater.UpdateValues(content, request.Values);
        }
        catch (Exception ex)
        {
            return Task.FromResult<ErrorOr<Unit>>(Error.Validation(
                code: "Content.InvalidValue",
                description: ex.Message
            ));
        }

        _contentRepository.Update(content);

        return Task.FromResult<ErrorOr<Unit>>(Unit.Value);
    }
}