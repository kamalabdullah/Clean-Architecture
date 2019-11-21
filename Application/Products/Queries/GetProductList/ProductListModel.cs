using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Application.Products.Queries.GetProductList
{
    public class ProductListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<string> ImageURLs { get; set; }
    }
}
