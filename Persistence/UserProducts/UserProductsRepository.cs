using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Persistence.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Persistence.UserProducts
{
    public class UserProductsRepository : Repository<Domain.UserProducts.UserProducts>, IUserProductsRepository
    {
        public UserProductsRepository(IDatabaseContext database) : base(database)
        {
        }
        public void AddRand(List<Domain.UserProducts.UserProducts> userProductsList)
        {
            _database.UserProducts.AddRange(userProductsList);
        }
    }
}
