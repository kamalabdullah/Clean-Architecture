using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Application.UserProducts.Commands.CreateUserProduct.Factory;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.UserProducts;
using CleanArchitecture.Domain.Users;

namespace CleanArchitecture. Application.UserProducts.Commands.CreateUserProduct.Repository
{
    public class UserProductsRepositoryFacade : IUserProductsRepositoryFacade
    {
        private readonly IProductRepository productRepository;
        private readonly IUserProductsRepository userProductRepository;
        private readonly IUserProductsFactory userProductsFactory;
        private readonly IUserRepository userRepository;

        public UserProductsRepositoryFacade(IUserRepository _userRepository,IProductRepository _productRepository,
            IUserProductsRepository _userProductRepository, IUserProductsFactory _userProductsFactory)
        {
            userRepository = _userRepository;
            productRepository = _productRepository;
            userProductRepository = _userProductRepository;
            userProductsFactory = _userProductsFactory;
        }

        public List<Product> GetProducts(List<int> Ids)
        {
           return this.productRepository.GetAll().Where(s=> Ids.Contains(s.Id)).ToList();
        }

        public User GetUser(int userId)
        {
            return this.userRepository.Get(userId);
        }

        public void AddUserProductsRang(CreateUserProductsModel userProductsModel)
        {
            var products = this.productRepository.GetAll().Where(s => userProductsModel.ProductsIds.Contains(s.Id)).ToList();
            var currentUser = this.userRepository.Get(userProductsModel.UserId);
            List<Domain.UserProducts.UserProducts> UserProductsList = new List<Domain.UserProducts.UserProducts>();
            foreach (var itemProduct in products)
            {
                UserProductsList.Add(this.userProductsFactory.Create(currentUser,itemProduct));
            }
            this.userProductRepository.AddRand(UserProductsList);
        }

    }
}
