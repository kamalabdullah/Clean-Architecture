using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Products;
using CleanArchitecture.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Domain.UserProducts
{
    public class UserProducts : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
