using FluentValidation;

namespace DialCMS.Application.Queries.GetContentById;

public class GetContentByIdQueryValidator : AbstractValidator<GetContentByIdQuery>
{
    public GetContentByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
    }
}