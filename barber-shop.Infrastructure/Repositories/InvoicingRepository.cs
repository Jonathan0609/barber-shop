using barber_shop.Domain.Entities;
using barber_shop.Domain.Repositories;
using barber_shop.Domain.Repositories.Invoicings;
using barber_shop.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace barber_shop.Infrastructure.Repositories;

internal class InvoicingRepository : IInvoicingWriteOnlyRepository, IInvoicingReadOnlyRepository
{
    private readonly BarberShopDbContext _context;
    
    public InvoicingRepository(BarberShopDbContext context)
    {
        _context = context;
    }
    
    public async Task Add(Invoicing invoicing)
    {
        await _context.Invoicings.AddAsync(invoicing);
    }
    
    public void Update(Invoicing invoicing)
    {
        _context.Invoicings.Update(invoicing);
    }

    public async Task<bool> Delete(Guid id)
    {
        var invoicing = await _context.Invoicings
            .FirstOrDefaultAsync(d => d.Id == id);
        
        if(invoicing == null)
            return false;
        
        _context.Invoicings.Remove(invoicing);
        
        return true;
    }

    public async Task<Invoicing?> GetById(Guid id)
    {
        return await _context.Invoicings
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<List<Invoicing>> GetAll()
    {
        return await _context.Invoicings
            .ToListAsync();
    }
}