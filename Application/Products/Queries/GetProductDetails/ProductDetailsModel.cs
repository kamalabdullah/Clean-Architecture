using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Application.Products.Queries.GetProductDetails
{
    public class ProductDetailsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FullDescription { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
    }
}
