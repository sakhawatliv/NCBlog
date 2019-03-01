using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCBlog.Model;
using NCBlog.Repository.DbContext;
using NCBlog.Repository.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NCBlog.Api.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    public class usersController : Controller
    {
        private IUsersRepository _userRepository;
        private NCBlogDbContext _context;

        public usersController(NCBlogDbContext context)
        {
            _context = context;
            _userRepository = new UsersRepository(_context);
        }
        // GET: api/<controller>
        [HttpGet]
        public IList<Users> GetAll()
        {
            return _userRepository.GetAll();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Users Get(int id)
        {

            return _userRepository.GetById(id);
        }

        // POST api/<controller>
        [HttpPost]
      
        public IActionResult Post([FromBody] Users users)
        {
            if (users.Id == 0)
            {
                _userRepository.Insert(users);
                return Ok();
            }
            else
            {
                _userRepository.Update(users);
                return Ok();
            }


        }
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
