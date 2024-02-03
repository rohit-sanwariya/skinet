

using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder
        .Property(x => x.Price)
        .IsRequired()
        .HasColumnType("decimal(18,2)");

        builder
        .HasOne(b => b.ProductBrand)
        .WithMany()
        .HasForeignKey(p => p.ProductBrandId);

        builder
        .HasOne(b => b.ProductType)
        .WithMany()
        .HasForeignKey(p => p.ProductTypeId);
    }
}
