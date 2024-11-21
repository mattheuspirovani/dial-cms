using FluentValidation;

namespace DialCMS.Application.Commands.UpdateContentValues;

public class UpdateContentValuesCommandValidator : AbstractValidator<UpdateContentValuesCommand>
{
    public UpdateContentValuesCommandValidator()
    {
        RuleFor(x => x.ContentId)
            .NotEmpty().WithMessage("ContentId is required.");

        RuleFor(x => x.Values)
            .NotEmpty().WithMessage("Values dictionary cannot be empty.");
    }
}