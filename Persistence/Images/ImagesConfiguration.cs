using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CleanArchitecture. Persistence.Images
{
    public class ImagesConfiguration : EntityTypeConfiguration<Domain.Images.Images>
    {
        public ImagesConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.ImageURL)
                .IsOptional()
                .HasMaxLength(500);

            HasRequired(p => p.Product);

            Property(p => p.IsDefault);
        }
    }
}
