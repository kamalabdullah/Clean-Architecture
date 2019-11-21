using System.Collections.Generic;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Users;

namespace CleanArchitecture.Application.UserProducts.Commands.CreateUserProduct.Factory
{
    public class UserProductsFactory : IUserProductsFactory
    {
        public Domain.UserProducts.UserProducts Create(User user, Product product)
        {
            Domain.UserProducts.UserProducts userProduct = new Domain.UserProducts.UserProducts();
            userProduct.Product = product;
            userProduct.User = user;
            return userProduct;
        }
        public List<Domain.UserProducts.UserProducts> CreateList(User user,List<Product> productList)
        {
            List<Domain.UserProducts.UserProducts> userProductList = new List<Domain.UserProducts.UserProducts>(); 
            foreach (var productItem in productList)
            {
                Domain.UserProducts.UserProducts userProduct = new Domain.UserProducts.UserProducts();
                userProduct.Product = productItem;
                userProduct.User = user;
                userProductList.Add(userProduct);
            }
            return userProductList;
        }
    }
}
