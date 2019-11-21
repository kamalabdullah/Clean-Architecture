using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture. Application.Products.Queries.GetProductList
{
    public interface IGetProductListQuery
    {
        List<ProductListModel> Execute(ProductFilter filter);
    }
}
