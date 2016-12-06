
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
    using CourseProjectServices.Contracts;
    public class HomeController : BaseController
    {
        private IPostService postsService;
        public HomeController(IPostService service)
        {
            this.postsService = service;
        }
        public ActionResult Index()
        {
            var posts = Mapper.Map<List<Post>,
                List<PostViewModel>>(postsService.GetAll().ToList());
            return View(posts);
        }

        public ActionResult Info(int id)
        {
            var post = Mapper.Map<PostViewModel>(this.postsService.Find(id));
            return View(post);
        }

    }
}