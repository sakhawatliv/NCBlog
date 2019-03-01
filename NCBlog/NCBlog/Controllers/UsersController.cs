using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NCBlog.Helpers;
using NCBlog.Models;

namespace NCBlog.Controllers
{
    public class UsersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var response = await NCBlogHttpClient.GetAsync("http://localhost:65031", $"api/Users", Request);
            var list = await response.Content.ReadAsAsync<List<UsersViewModel>>() ?? new List<UsersViewModel>();
            return View(list);
        }

        [HttpGet]
        public async Task<ActionResult> Create()
        {
            var response = await NCBlogHttpClient.GetAsync("http://localhost:65031", $"api/UserTypes", Request);
            var list = await response.Content.ReadAsAsync<List<UserTypesViewModel>>() ?? new List<UserTypesViewModel>();
            ViewData["UserTypesId"] = new SelectList(list, "Id", "TypeName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsersViewModel model)
        {

            if (ModelState.IsValid)
            {
                //model.CreateDate = DateTime.UtcNow;
                //model.CreateBy = currentUser.UserId;
                var response = await NCBlogHttpClient.PostAsync("http://localhost:65031", $"api/Users", model, Request);
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