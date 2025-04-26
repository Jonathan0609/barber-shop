using barber_shop.Domain.Entities;

namespace barber_shop.Domain.Repositories.Invoicings;

public interface IInvoicingReadOnlyRepository
{
    Task<Invoicing?> GetById(Guid id);
    
    Task<List<Invoicing>> GetAll();
}