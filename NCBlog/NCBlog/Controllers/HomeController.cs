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

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model.CreateDate = DateTime.UtcNow;
                //model.CreateBy = currentUser.UserId;
                var response = await NCBlogHttpClient.PostAsync("http://localhost:65031", $"api/BlogPosts", model, Request);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }

            return View(model);
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
