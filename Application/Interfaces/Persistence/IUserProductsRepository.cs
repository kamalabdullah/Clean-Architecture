using CleanArchitecture.Domain.UserProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.Interfaces.Persistence
{
    public interface IUserProductsRepository : IRepository<Domain.UserProducts.UserProducts>
    {
        void AddRand(List<Domain.UserProducts.UserProducts> userProductsList);
    }
}
