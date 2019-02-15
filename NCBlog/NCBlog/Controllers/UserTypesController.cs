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
    public class UserTypesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await NCBlogHttpClient.GetAsync("http://localhost:65031", $"api/UserTypes", Request);
            var list = await response.Content.ReadAsAsync<List<UserTypesViewModel>>() ?? new List<UserTypesViewModel>();
            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserTypesViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model.CreateDate = DateTime.UtcNow;
                //model.CreateBy = currentUser.UserId;
                var response = await NCBlogHttpClient.PostAsync("http://localhost:65031", $"api/UserTypes",model,Request);
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
    }
}