using FluentValidation;

namespace DialCMS.Application.Commands.Contents.CreateContent;

public class CreateContentCommandValidator: AbstractValidator<CreateContentCommand>
{
    public CreateContentCommandValidator()
    {
        RuleFor(x => x.ContentTypeId).NotEmpty().WithMessage("ContentTypeId is required.");
    }
}