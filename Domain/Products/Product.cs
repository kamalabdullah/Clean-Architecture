using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Domain.Products
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FullDescription { get; set; }
        public double? Price { get; set; }
        public List<Domain.Images.Images> ProductImages { get; set; }
    }
}
