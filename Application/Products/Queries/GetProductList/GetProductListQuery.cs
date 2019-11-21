using CleanArchitecture.Application.Interfaces.Persistence;
using CleanArchitecture.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CleanArchitecture. Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IGetProductListQuery
    {
        public IProductRepository productRepository;
        public GetProductListQuery(IProductRepository _productRepository)
        {
            productRepository = _productRepository;
        }

        public List<ProductListModel> Execute(ProductFilter filter)
        {
            List<ProductListModel> productList = new List<ProductListModel>();
            if (filter != null && filter.minPrice > 0 && filter.maxPrice > 0)
            {
                productList = productRepository.GetAll().Where(s => s.Price >= filter.minPrice && s.Price <= filter.maxPrice).Select(p => new ProductListModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageURLs = p.ProductImages.Select(s => s.ImageURL).ToList(),
                    Price = p.Price.Value
                }).ToList();
            }
            else
            {
                productList = productRepository.GetAll().Select(p => new ProductListModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageURLs = p.ProductImages.Select(s => s.ImageURL).ToList(),
                    Price = p.Price.Value
                }).ToList();
            }
            
            return productList;
        }
    }
}
