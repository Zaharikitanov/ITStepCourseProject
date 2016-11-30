using CourseProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseProject.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var posts = this.Data.Posts.All().ToList();
            return View(new List<PostViewModel>());
        }

    }
}