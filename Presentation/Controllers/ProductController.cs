using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Products.Queries.GetProductDetails;
using CleanArchitecture.Application.Products.Queries.GetProductList;
using CleanArchitecture.Application.UserProducts.Commands.CreateUserProduct;
using CleanArchitecture.Application.UserProducts.Commands.CreateUserProduct.Factory;
using CleanArchitecture.Application.UserProducts.Commands.CreateUserProduct.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture. Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IGetProductListQuery _listQuery;
        private readonly IGetProductDetailsQuery _detailsQuery;
        private readonly IUserProductsRepositoryFacade _userProductsRepositoryFacade;
        private readonly IUserProductsFactory _userProductsFactory;

        public ProductController(IGetProductListQuery listQuery, IGetProductDetailsQuery detailsQuery,
            IUserProductsRepositoryFacade userProductsRepositoryFacade, IUserProductsFactory userProductsFactory)
        {
            _listQuery = listQuery;
            _detailsQuery = detailsQuery;
            _userProductsRepositoryFacade = userProductsRepositoryFacade;
            _userProductsFactory = userProductsFactory;
        }

        [HttpPost("GetAllProduct")]
        public IActionResult GetAllProduct([FromBody] ProductFilter filter)
        {
            try
            {
                return Ok(_listQuery.Execute(filter));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                return Ok( _detailsQuery.Execute(id));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("SubmitUserProducts")]
        public IActionResult SubmitUserProducts([FromQuery]int userId, [FromBody] List<int> productIds)
        {
            try
            {
                CreateUserProductsModel userProductModel = new CreateUserProductsModel(userId, productIds);
                _userProductsRepositoryFacade.AddUserProductsRang(userProductModel);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}