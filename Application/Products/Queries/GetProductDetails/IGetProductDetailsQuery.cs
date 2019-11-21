using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Application.Products.Queries.GetProductDetails
{
    public interface IGetProductDetailsQuery
    {
        ProductDetailsModel Execute(int Id);
    }
}
