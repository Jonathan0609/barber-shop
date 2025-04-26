using barber_shop.Communication.Requests.Invoincing;
using barber_shop.Communication.Responses.Invoicing;

namespace barber_shop.Application.UseCases.Invoicing.Create;

public interface IInvoicingCreateUseCase
{
    public Task<InvoicingCreateResponse> Execute(InvoicingCreateRequest request);
}