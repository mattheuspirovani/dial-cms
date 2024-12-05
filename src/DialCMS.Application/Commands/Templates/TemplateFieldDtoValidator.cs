using DialCMS.Domain.ValueObjects;
using FluentValidation;

namespace DialCMS.Application.Commands.Templates;

public class TemplateFieldDtoValidator : AbstractValidator<TemplateField>
{
    public TemplateFieldDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Template name is required.")
            .MaximumLength(100).WithMessage("Template name must not exceed 100 characters.");

        RuleFor(x => x.Type)
            .IsInEnum().WithMessage("The type itself is invalid.");
    }
}