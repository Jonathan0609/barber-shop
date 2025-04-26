using barber_shop.Domain.Repositories;

namespace barber_shop.Infrastructure.DataAccess;

internal class UnitOfWork: IUnitOfWork
{
    private readonly BarberShopDbContext _context;
    
    public UnitOfWork(BarberShopDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync() => await _context.SaveChangesAsync();
}