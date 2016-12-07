
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
    using Common.Caching;
    public class HomeController : BaseController
    {
        private IPostService postsService;
        private ICacheService cache;
        public HomeController(IPostService service, ICacheService cache)
        {
            this.cache = cache;
            this.postsService = service;
        }
        public ActionResult Index()
        {
            var dbPosts = this.cache.Get<ICollection<Post>>("allPosts", () =>
            {
                return postsService.GetAll().ToList();
            }, 60 * 60
            ); 
            var posts = Mapper.Map<ICollection<Post>,
                List<PostViewModel>>(dbPosts);
            return View(posts);
        }

        public ActionResult Info(int id)
        {
            var post = Mapper.Map<PostViewModel>(this.postsService.Find(id));
            if (post.Content.Length > 30)
            {
                post.SubHeader = post.Content.Substring(0, 30);
            }
            else
            {
                post.SubHeader = post.Content;
            }
            
            return View(post);
        }

    }
}