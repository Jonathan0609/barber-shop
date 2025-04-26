using barber_shop.Communication.Enums;
using barber_shop.Communication.List;
using barber_shop.Communication.Requests.Invoincing;
using barber_shop.Communication.Responses.Invoicing;
using barber_shop.Domain.Repositories.Invoicings;

namespace barber_shop.Application.UseCases.Invoicing.List;

public class InvoicingListUseCase: IInvoicingListUseCase
{
    private readonly IInvoicingReadOnlyRepository _invoicingReadOnlyRepository;
    
    public InvoicingListUseCase(IInvoicingReadOnlyRepository invoicingReadOnlyRepository)
    {
        _invoicingReadOnlyRepository = invoicingReadOnlyRepository;
    }
    public async Task<ListReturn<InvoicingDetailResponse>> Execute(InvoicingListRequest request)
    {
        var invoices = await _invoicingReadOnlyRepository.GetAll();

        return new ListReturn<InvoicingDetailResponse>
        {
            Data = invoices.Select(invoice =>
                new InvoicingDetailResponse(
                Id: invoice.Id,
                Title: invoice.Title,
                Description: invoice.Description,
                PaymentType: (PaymentType)invoice.PaymentType,
                Date: invoice.Date,
                Value: invoice.Value)
            ).ToList()
        };
    }
}