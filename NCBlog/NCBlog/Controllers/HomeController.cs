using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NCBlog.Helpers;
using NCBlog.Models;

namespace NCBlog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var lsitCountry = NCBlogHttpClient.GetAsync<List<string>>("http://localhost:62876", $"api/values", Request);
            return View();
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
