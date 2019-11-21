using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Domain.Images
{
    public class Images: IEntity
    {
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public Product Product { get; set; }
        public bool IsDefault { get; set; }
    }
}
