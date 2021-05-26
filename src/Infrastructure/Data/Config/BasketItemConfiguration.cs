using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sula.Shipment.ApplicationCore.Entities.BasketAggregate;

namespace Sula.Shipment.Infrastructure.Data.Config
{
    public class BasketItemConfiguration : IEntityTypeConfiguration<BasketItem>
    {
        public void Configure(EntityTypeBuilder<BasketItem> builder)
        {
            builder.Property(bi => bi.UnitPrice)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");
        }
    }
}
