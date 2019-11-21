using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Domain.Users
{
    public class User:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
