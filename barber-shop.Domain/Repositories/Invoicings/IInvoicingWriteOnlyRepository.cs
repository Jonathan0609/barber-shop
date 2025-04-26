using barber_shop.Domain.Entities;

namespace barber_shop.Domain.Repositories.Invoicings;

public interface IInvoicingWriteOnlyRepository
{
    Task Add(Invoicing invoicing);
    
    void Update(Invoicing invoicing);
    
    Task<bool> Delete(Guid id);
}