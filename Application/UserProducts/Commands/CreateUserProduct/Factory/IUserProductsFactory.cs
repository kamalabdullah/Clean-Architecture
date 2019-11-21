using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Application.UserProducts.Commands.CreateUserProduct.Factory
{
    public interface IUserProductsFactory
    {
        Domain.UserProducts.UserProducts Create(User user, Product product);
        List<Domain.UserProducts.UserProducts> CreateList(User user, List<Product> productList);
    }
}
