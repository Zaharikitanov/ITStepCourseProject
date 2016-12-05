
namespace CourseProject.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using CourseProject.Data;
    using CourseProject.Controllers;
    using CourseProject.Areas.Administration.ViewModels;
    using CourseProjectServices.Contracts;
    public class PostsController : BaseController
    {
        private CourseProjectDbContext db = new CourseProjectDbContext();

        private IPostService postsService;
        private IUsersService usersService;
        public PostsController(IPostService postService, IUsersService userService)
        {
            this.postsService = postService;
            this.usersService = userService;
        }
        // GET: Administration/Posts
        public ActionResult Index()
        {
            var posts = Mapper.Map<List<Post>,
                List<PostViewModel>>(postsService.GetAll().ToList());
            return View(posts);
        }

        // GET: Administration/Posts/Create
        public ActionResult Create()
        {
            PostViewModel postVM = new PostViewModel();
            postVM.Users = new SelectList(this.usersService.GetAll(), "Id", "Email");
            return View(postVM);
        }

        // POST: Administration/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var dbPost = Mapper.Map<Post>(post);
                this.postsService.Add(dbPost);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(this.postsService.GetAll(), "Id", "Email", post.AuthorId);
            return View(post);
        }

        [ValidateInput(false)]
        // GET: Administration/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = this.postsService.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            PostViewModel postVM = Mapper.Map<PostViewModel>(post);
            postVM.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", post.AuthorId);
            return View(postVM);
        }

        // POST: Administration/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(PostViewModel post)
        {
            if (ModelState.IsValid)
            {
                var dbPost = Mapper.Map<Post>(post);
                this.postsService.Update(dbPost);
                return RedirectToAction("Index");
            }
            post.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", post.AuthorId);
            return View(post);
        }

        // GET: Administration/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = this.postsService.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Administration/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.postsService.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
