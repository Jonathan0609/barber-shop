using System.ComponentModel.DataAnnotations.Schema;
using barber_shop.Domain.Enums;

namespace barber_shop.Domain.Entities;

public class Invoicing
{
    public Guid Id { get; set; }
    
    public string Title { get; set; } = string.Empty;
    
    public string? Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public decimal Value { get; set; }
    
    [Column("payment_type")]
    public PaymentType PaymentType { get; set; }
}