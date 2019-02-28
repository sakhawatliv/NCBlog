using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCBlog.Helpers;
using NCBlog.Models;

namespace NCBlog.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await NCBlogHttpClient.GetAsync("http://localhost:65031", $"api/BlogPosts", Request);
            var list = await response.Content.ReadAsAsync<List<BlogPostViewModel>>() ?? new List<BlogPostViewModel>();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            var list = await NCBlogHttpClient.GetAsync<BlogPostViewModel>("http://localhost:65031", $"api/BlogPosts/{id}",
                Request);
            if (list != null)
            {
                return View(list);
            }
            else
            {
               return NotFound();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
