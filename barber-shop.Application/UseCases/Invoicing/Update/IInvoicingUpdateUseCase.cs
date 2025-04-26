using barber_shop.Communication.Requests.Invoincing;

namespace barber_shop.Application.UseCases.Invoicing.Update;

public interface IInvoicingUpdateUseCase
{
    Task Execute(Guid id, InvoicingUpdateRequest request);
}