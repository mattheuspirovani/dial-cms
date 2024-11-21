using FluentValidation;

namespace DialCMS.Application.Commands.CreateContentType;

public class CreateContentTypeCommandValidator : AbstractValidator<CreateContentTypeCommand>
{
    public CreateContentTypeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.");
        RuleFor(x => x.Fields).NotEmpty().WithMessage("At least one field is required.");
    }
}