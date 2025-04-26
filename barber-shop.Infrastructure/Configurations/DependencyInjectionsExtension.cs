using barber_shop.Domain.Repositories;
using barber_shop.Domain.Repositories.Invoicings;
using barber_shop.Infrastructure.DataAccess;
using barber_shop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace barber_shop.Infrastructure.Configurations;

public static class DependencyInjectionsExtension
{
    public static void AddInfraDependencyInjections(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services,configuration);
        AddRepositories(services);
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IInvoicingWriteOnlyRepository, InvoicingRepository>();
        services.AddScoped<IInvoicingReadOnlyRepository, InvoicingRepository>();
    }
    
    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        
        services.AddDbContext<BarberShopDbContext>(config => config.UseNpgsql(connectionString));
    }
}