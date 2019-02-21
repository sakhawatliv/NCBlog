using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCBlog.Helpers;
using NCBlog.Models;

namespace NCBlog.Controllers
{
    public class BlogPostsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await NCBlogHttpClient.GetAsync("http://localhost:65031", $"api/BlogPosts", Request);
            var list = await response.Content.ReadAsAsync<List<BlogPostViewModel>>() ?? new List<BlogPostViewModel>();
            return View(list);
        }
    }
}