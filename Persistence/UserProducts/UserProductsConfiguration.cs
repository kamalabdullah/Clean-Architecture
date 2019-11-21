using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CleanArchitecture. Persistence.UserProducts
{
    public class UserProductsConfiguration : EntityTypeConfiguration<Domain.UserProducts.UserProducts>
    {
        public UserProductsConfiguration()
        {
            HasKey(p => p.Id);
            HasRequired(p => p.Product);
            HasRequired(p => p.User);
        }
    }
}
