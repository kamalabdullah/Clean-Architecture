using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Application.UserProducts.Commands.CreateUserProduct
{
    public class CreateUserProductsModel
    {
        public CreateUserProductsModel()
        {
        }
        public CreateUserProductsModel(int userId,List<int>prodcutsIds)
        {
            UserId = userId;
            ProductsIds = prodcutsIds;
        }
        public int UserId { get; set; }
        public List<int> ProductsIds { get; set; }
    }
}
