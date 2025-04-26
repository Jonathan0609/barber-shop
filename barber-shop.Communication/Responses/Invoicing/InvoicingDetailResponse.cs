using barber_shop.Communication.Enums;

namespace barber_shop.Communication.Responses.Invoicing;

public record InvoicingDetailResponse(
    Guid Id, 
    string Title, 
    string? Description, 
    PaymentType PaymentType,
    DateTime Date, 
    decimal Value)
{
}