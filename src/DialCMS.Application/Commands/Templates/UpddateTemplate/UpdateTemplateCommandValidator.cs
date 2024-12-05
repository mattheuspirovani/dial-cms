using FluentValidation;

namespace DialCMS.Application.Commands.Templates.UpddateTemplate;

public class UpdateTemplateCommandValidator : AbstractValidator<UpdateTemplateCommand>
{
    public UpdateTemplateCommandValidator()
    {
        RuleFor(x => x.TemplateId)
            .NotEmpty().WithMessage("Template ID is required.");
        RuleFor(x => x.Template.Name)
            .NotEmpty().WithMessage("Template name is required.")
            .MaximumLength(100).WithMessage("Template name must not exceed 100 characters.");
        RuleForEach(x => x.Template.Fields).SetValidator(new TemplateFieldDtoValidator());
    }
}