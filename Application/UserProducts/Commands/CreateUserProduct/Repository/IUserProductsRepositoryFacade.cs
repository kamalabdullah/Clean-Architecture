using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Application.UserProducts.Commands.CreateUserProduct.Repository
{
    public interface IUserProductsRepositoryFacade
    {
        User GetUser(int userId);
        List<Product> GetProducts(List<int> Ids);

        void AddUserProductsRang(CreateUserProductsModel userProductsModel);
    }
}
