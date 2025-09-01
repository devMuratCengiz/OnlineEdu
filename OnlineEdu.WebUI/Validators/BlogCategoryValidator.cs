using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;

namespace OnlineEdu.WebUI.Validators
{
    public class BlogCategoryValidator : AbstractValidator<CreateBlogCategoryDto>
    {
        public BlogCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("This field cannot be empty.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("This field must be at most 30 characters long.");
        }
    }
}
