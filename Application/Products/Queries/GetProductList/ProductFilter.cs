using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Application.Products.Queries.GetProductList
{
    public class ProductFilter
    {
        public int minPrice { get; set; }
        public int maxPrice { get; set; }
    }
}
