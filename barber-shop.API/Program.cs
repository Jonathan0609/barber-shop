using barber_shop.API.Filters;
using barber_shop.API.Middleware;
using barber_shop.Application.UseCases.Invoicing.Configuration;
using barber_shop.Infrastructure.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInvoicingDependencyInjections();
builder.Services.AddInfraDependencyInjections(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
