using barber_shop.Communication.Requests.Invoincing;

namespace barber_shop.Application.UseCases.Invoicing.Delete;

public interface IInvoicingDeleteUseCase
{
    Task Execute(Guid id);
}