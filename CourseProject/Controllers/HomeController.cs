
namespace CourseProject.Controllers
{
    using CourseProject.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var posts = Mapper.Map<List<Post>,
                List<PostViewModel>>(Data.Posts.All().ToList());
            return View(posts);
        }

    }
}