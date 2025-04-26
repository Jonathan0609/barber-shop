using barber_shop.Communication.List;
using barber_shop.Communication.Requests.Invoincing;
using barber_shop.Communication.Responses.Invoicing;

namespace barber_shop.Application.UseCases.Invoicing.List;

public interface IInvoicingListUseCase
{
    Task<ListReturn<InvoicingDetailResponse>> Execute(InvoicingListRequest request);
}