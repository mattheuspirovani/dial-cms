using MediatR;
using ErrorOr;

namespace DialCMS.Application.Commands.UpdateContentValues;

public class UpdateContentValuesCommand : IRequest<ErrorOr<Unit>>
{
    public Guid ContentId { get; set; }
    public Dictionary<string, Dictionary<string, object>> Values { get; set; } = new();
}