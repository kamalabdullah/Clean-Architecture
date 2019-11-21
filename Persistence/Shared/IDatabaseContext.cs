using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.UserProducts;
using CleanArchitecture.Domain.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace CleanArchitecture.Persistence.Shared
{
    public interface IDatabaseContext
    {
        public IDbSet<Product> Product { get; set; }
        public IDbSet<User> User { get; set; }
        public DbSet<Domain.UserProducts.UserProducts> UserProducts { get; set; }

        IDbSet<T> Set<T>() where T : class, IEntity;

        void Save();
    }
}
