using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCBlog.Model;

namespace NCBlog.Api.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    public class UserTypesController : Controller
    {
        private List<UserTypes> userTypeses;
        [HttpGet]
        public List<UserTypes> GetAll()
        {
            userTypeses =  new List<UserTypes>()
            {
                new UserTypes
                {
                    Id = 1,
                    TypeName = "Admin"
                },
                new UserTypes
                {
                    Id = 2,
                    TypeName = "User"
                }
            };
            return userTypeses;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserTypes userTypes)
        {

            userTypeses.Add(userTypes);
            return Ok();
        }
    }
}