using FluentValidation;
using TadbirPardazProject.Domain.Invoices;

namespace TadbirPardazProject.Application.Invoices.Commands.Create
{
    public class InvoiceCreateCommandValidator : AbstractValidator<InvoiceCreateCommand>
    {
        public InvoiceCreateCommandValidator()
        {
            RuleFor(p => p.IssuedDate)
                .NotEmpty().WithName("تاریخ").WithMessage("{PropertyName} الزامی است")
                .GreaterThan(p => DateTime.Now.AddYears(-10)).WithMessage("{PropertyName} نامعتبر می باشد. (حداقل می تواند ده سال قبل باشد)");

            RuleFor(p => p.CustomerName)
                .NotEmpty().WithName("نام خریدار").WithMessage("{PropertyName} الزامی است");

            RuleFor(p => p.InvoiceDetails)
                .NotNull().WithName("سفارشی").WithMessage("هیچ {PropertyName} درج نشده است");

            RuleForEach(p => p.InvoiceDetails).SetValidator(new InvoiceDetailCreateCommandValidator());
        }


        public class InvoiceDetailCreateCommandValidator : AbstractValidator<InvoiceDetailCreateCommand>
        {
            public InvoiceDetailCreateCommandValidator()
            {
                RuleFor(p => p.ProductId)
                    .GreaterThan(0).WithName("کد محصول")
                    .WithMessage("{PropertyName} باید بزرگتر از 0 باشد");

                RuleFor(p => p.Quantity)
                    .InclusiveBetween(1, 10000).WithName("تعداد")
                    .WithMessage("{PropertyName} درصد تخفیف محصول باید بین 1 تا 10000 باشد");

                RuleFor(p => p.DiscountPercent)
                    .InclusiveBetween(0, 100).WithName("درصد تخفیف")
                    .WithMessage("{PropertyName} درصد تخفیف محصول باید بین 0 تا 100 باشد");
            }
        }
    }
}
