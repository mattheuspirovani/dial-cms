using DialCMS.Domain.ValueObjects;
using FluentValidation;

namespace DialCMS.Application.Commands.CreateTemplate;

public class CreateTemplateCommandValidator : AbstractValidator<CreateTemplateCommand>
{
    public CreateTemplateCommandValidator()
    {
        RuleFor(x => x.Template.Name)
            .NotEmpty().WithMessage("Template name is required.")
            .MaximumLength(100).WithMessage("Template name must not exceed 100 characters.");

        RuleFor(x => x.Template.Fields)
            .NotNull().WithMessage("Template fields are required.")
            .Must(fields => fields.Any()).WithMessage("At least one field is required.");

        RuleForEach(x => x.Template.Fields).SetValidator(new TemplateFieldDtoValidator());
    }
}

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