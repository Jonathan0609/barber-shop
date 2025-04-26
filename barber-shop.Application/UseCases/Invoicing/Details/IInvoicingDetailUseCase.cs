using barber_shop.Communication.Responses.Invoicing;

namespace barber_shop.Application.UseCases.Invoicing.Details;

public interface IInvoicingDetailUseCase
{
    Task<InvoicingDetailResponse> Execute(Guid invoiceId);
}