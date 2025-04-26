using barber_shop.Application.UseCases.Invoicing.Create;
using barber_shop.Application.UseCases.Invoicing.Delete;
using barber_shop.Application.UseCases.Invoicing.Details;
using barber_shop.Application.UseCases.Invoicing.List;
using barber_shop.Application.UseCases.Invoicing.Update;
using Microsoft.Extensions.DependencyInjection;

namespace barber_shop.Application.UseCases.Invoicing.Configuration;

public static class InvoicingDependencyInjectionExtension
{
    public static void AddInvoicingDependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<IInvoicingCreateUseCase, InvoicingCreateUseCase>();
        services.AddScoped<IInvoicingDetailUseCase, InvoicingDetailUseCase>();
        services.AddScoped<IInvoicingUpdateUseCase, InvoicingUpdateUseCase>();
        services.AddScoped<IInvoicingDeleteUseCase, InvoicingDeleteUseCase>();
        services.AddScoped<IInvoicingListUseCase, InvoicingListUseCase>();
    }
}