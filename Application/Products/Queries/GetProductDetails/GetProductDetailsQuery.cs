using CleanArchitecture.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery : IGetProductDetailsQuery
    {
        private readonly IProductRepository productRepository;

        public GetProductDetailsQuery(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }
        public ProductDetailsModel Execute(int Id)
        {
            return this.productRepository.GetAll().Where(s => s.Id == Id).Select(p => new ProductDetailsModel
            {
                Id = p.Id,
                FullDescription = p.FullDescription,
                ImageURL = p.ProductImages.FirstOrDefault(s => s.IsDefault).ImageURL,
                Name = p.Name,
                Price = p.Price.Value
            }).Single();
        }
    }
}
