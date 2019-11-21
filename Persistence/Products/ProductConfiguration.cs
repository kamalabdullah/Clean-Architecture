using CleanArchitecture.Domain.Products;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CleanArchitecture. Persistence.Products
{
    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(256);

            Property(p => p.Price)
                .IsOptional()
                .HasColumnType("float");

            Property(p => p.Description).HasMaxLength(256);

            Property(p => p.FullDescription).HasMaxLength(1000);

        }
    }
}
