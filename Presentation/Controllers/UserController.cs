using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Application.Users.Queries.GetUser;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture. Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IGetUserQuery userQuery;

        public UserController(IGetUserQuery _userQuery)
        {
            this.userQuery = _userQuery;
        }

        [HttpGet("GetUserByUserName")]
        public IActionResult GetUserByUserName(string userName)
        {
            try
            {
                return Ok(this.userQuery.Execute(userName));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }
    }
}
