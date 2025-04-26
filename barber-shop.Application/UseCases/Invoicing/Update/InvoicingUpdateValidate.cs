using barber_shop.Communication.Requests.Invoincing;
using FluentValidation;

namespace barber_shop.Application.UseCases.Invoicing.Update;

public class InvoicingUpdateValidate: AbstractValidator<InvoicingUpdateRequest>
{
    public InvoicingUpdateValidate()
    {
        RuleFor(d => d.Description).NotEmpty();
        
        RuleFor(d => d.Value).NotEmpty();
        
        RuleFor(d => d.Date).NotNull();

        RuleFor(expense => expense.PaymentType)
            .IsInEnum();
    }
}