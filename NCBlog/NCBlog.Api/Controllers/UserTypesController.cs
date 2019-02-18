using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCBlog.Model;
using NCBlog.Repository.DbContext;
using NCBlog.Repository.UserTypes;

namespace NCBlog.Api.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    public class UserTypesController : Controller
    {
        private List<UserTypes> userTypeses;
        private IUserTypesRepository _userTypesRepository;
        private NCBlogDbContext _context;

        public UserTypesController()
        {
            _userTypesRepository = new UserTypesRepository(_context);
        }
        [HttpGet]
        //public List<UserTypes> GetAll()
        //{
        //    userTypeses =  new List<UserTypes>()
        //    {
        //        new UserTypes
        //        {
        //            Id = 1,
        //            TypeName = "Admin"
        //        },
        //        new UserTypes
        //        {
        //            Id = 2,
        //            TypeName = "User"
        //        }
        //    };
        //    return userTypeses;
        //}

        public UserTypes GetById(int d)
        {
           return _userTypesRepository.GetById(1);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserTypes userTypes)
        {

            await _userTypesRepository.Insert(userTypes);
            return Ok();
        }
    }
}