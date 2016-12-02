
namespace CourseProject.Controllers
{
    using CourseProject.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using static App_Start.NinjectWebCommon;
    using Data;
    public class HomeController : BaseController
    {
        public HomeController(ICourseProjectData data)
            :base(data)
        {

        }
        public ActionResult Index()
        {
            var posts = Mapper.Map<List<Post>,
                List<PostViewModel>>(Data.Posts.All().ToList());
            return View(posts);
        }

    }
}