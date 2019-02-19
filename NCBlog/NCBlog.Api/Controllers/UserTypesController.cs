using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
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

        public UserTypesController(NCBlogDbContext context)
        {
            _context = context;
            _userTypesRepository = new UserTypesRepository(_context);
        }
        [HttpGet]
        public IList<UserTypes> GetAll()
        {
            return _userTypesRepository.GetAll();
        }
        [HttpGet("{id}")]
        public UserTypes GetById([FromRoute]int id)
        {
            return _userTypesRepository.GetById(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] UserTypes userTypes)
        {
            if (userTypes.Id == 0)
            {
                _userTypesRepository.Insert(userTypes);
                return Ok();
            }
            else
            {
                _userTypesRepository.Update(userTypes);
                return Ok();
            }

            
        }
    }
}