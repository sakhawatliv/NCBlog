using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCBlog.Model;
using NCBlog.Repository.DbContext;
using NCBlog.Repository.Post;

namespace NCBlog.Api.Controllers
{
    [Produces("Application/json")]
    [Route("api/[controller]")]
    public class BlogPostsController : Controller
    {
        private IPostRepository _postRepository;
        private NCBlogDbContext _context;

        public BlogPostsController(NCBlogDbContext context)
        {
            _context = context;
            _postRepository = new PostRepository(_context);
        }
        
        [HttpGet]
        public IList<BlogPost> GetAll()
        {
            return _postRepository.GetAll();
        }
        [HttpGet("{id}")]
        public BlogPost GetById([FromRoute]int id)
        {
            return _postRepository.GetById(id);
        }
        [HttpPost]
        public IActionResult Post([FromBody] BlogPost blogPost)
        {
            if (blogPost.Id == 0)
            {
                _postRepository.Insert(blogPost);
                return Ok();
            }
            else
            {
                _postRepository.Update(blogPost);
                return Ok();
            }


        }
    }
}