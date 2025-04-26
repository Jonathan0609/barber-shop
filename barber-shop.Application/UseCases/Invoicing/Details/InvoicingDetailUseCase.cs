using barber_shop.Communication.Enums;
using barber_shop.Communication.Responses.Invoicing;
using barber_shop.Domain.Repositories.Invoicings;
using barber_shop.Exception;

namespace barber_shop.Application.UseCases.Invoicing.Details;

public class InvoicingDetailUseCase : IInvoicingDetailUseCase
{
    public readonly IInvoicingReadOnlyRepository _invoicingReadOnlyRepository;

    public InvoicingDetailUseCase(IInvoicingReadOnlyRepository invoicingReadOnlyRepository)
    {
        _invoicingReadOnlyRepository = invoicingReadOnlyRepository;
    }
    
    public async Task<InvoicingDetailResponse> Execute(Guid invoiceId)
    {
        var result = await _invoicingReadOnlyRepository.GetById(invoiceId);
        
        if (result is null)
            throw new NotFoundException(ResourceErrorMessages.INVOICING_NOT_FOUND);

        return new InvoicingDetailResponse(
            result.Id,
            result.Title,
            result.Description,
            (PaymentType)result.PaymentType,
            result.Date,
            result.Value);
    }
}