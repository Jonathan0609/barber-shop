using barber_shop.Communication.Enums;

namespace barber_shop.Communication.Requests.Invoincing;

public class InvoicingUpdateRequest
{
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public decimal Value { get; set; }
    
    public PaymentType PaymentType { get; set; }
}