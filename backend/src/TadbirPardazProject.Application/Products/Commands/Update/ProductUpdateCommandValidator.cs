using FluentValidation;

namespace TadbirPardazProject.Application.Products.Commands.Update
{
    public class ProductUpdateCommandValidator : AbstractValidator<ProductUpdateCommand>
    {
        public ProductUpdateCommandValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithName("عنوان").WithMessage("{PropertyName} الزامی است")
                .MaximumLength(100).WithMessage("{عنوان} نمی تواند بیش از 100 کاراکتر باشد");

            RuleFor(p => p.Price)
                .GreaterThan(0).WithName("مبلغ").WithMessage("{PropertyName} باید بزرگتر از 0 باشد");
        }
    }
}
