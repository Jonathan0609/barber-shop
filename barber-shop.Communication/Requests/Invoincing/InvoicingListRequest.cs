using barber_shop.Communication.Enums;

namespace barber_shop.Communication.Requests.Invoincing;

public class InvoicingListRequest
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public DateTime? Date { get; set; }
    
    public PaymentType? PaymentType { get; set; }
}