using barber_shop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace barber_shop.Infrastructure.ConfigurationsEntities;

public class InvoicingConfiguration : IEntityTypeConfiguration<Invoicing>
{
    public void Configure(EntityTypeBuilder<Invoicing> entity)
    {
        entity.ToTable("invoicings", "barbershopdb");

        entity.Property(e => e.Id).HasColumnName("id");
        entity.Property(e => e.Title).HasColumnName("title");
        entity.Property(e => e.Description).HasColumnName("description");
        entity.Property(e => e.Date).HasColumnName("date");
        entity.Property(e => e.Value).HasColumnName("value");
        entity.Property(e => e.PaymentType).HasColumnName("payment_type");
    }
}