using barber_shop.Communication.Requests.Invoincing;
using barber_shop.Exception;
using FluentValidation;

namespace barber_shop.Application.UseCases.Invoicing.Create;

public class InvoicingCreateValidate: AbstractValidator<InvoicingCreateRequest>
{
    public InvoicingCreateValidate()
    {
        RuleFor(d => d.Title)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.TITLE_NOT_EMPTY);
        
        RuleFor(d => d.Value).NotEmpty();
        
        RuleFor(d => d.Date).NotNull();

        RuleFor(expense => expense.PaymentType)
            .IsInEnum();
    }
}