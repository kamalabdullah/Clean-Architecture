using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.UserProducts;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Persistence.Images;
using CleanArchitecture.Persistence.Products;
using CleanArchitecture.Persistence.UserProducts;
using CleanArchitecture.Persistence.Users;

namespace CleanArchitecture. Persistence.Shared
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public IDbSet<Product> Product { get; set; }
        public IDbSet<User> User { get; set; }
        public DbSet<Domain.UserProducts.UserProducts> UserProducts { get; set; }

        public DatabaseContext() : base("CleanArchitecture")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }
        public void Save()
        {
            this.SaveChangesAsync();
        }

        IDbSet<T> IDatabaseContext.Set<T>()
        {
            return base.Set<T>();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ImagesConfiguration());
            modelBuilder.Configurations.Add(new UserProductsConfiguration());
        }
    }
}
