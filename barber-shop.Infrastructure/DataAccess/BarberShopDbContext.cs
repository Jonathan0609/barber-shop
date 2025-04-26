using barber_shop.Domain.Entities;
using barber_shop.Infrastructure.ConfigurationsEntities;
using Microsoft.EntityFrameworkCore;

namespace barber_shop.Infrastructure.DataAccess;

public class BarberShopDbContext : DbContext
{
    public BarberShopDbContext(DbContextOptions options): base(options) { }
    
    public DbSet<Invoicing> Invoicings { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder) => 
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BarberShopDbContext).Assembly);
}