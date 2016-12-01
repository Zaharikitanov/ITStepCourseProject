
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
    public class PostsController : BaseController
    {
        private CourseProjectDbContext db = new CourseProjectDbContext();

        // GET: Administration/Posts
        public ActionResult Index()
        {
            var posts = Mapper.Map<List<Post>,
                List<PostViewModel>>(Data.Posts.All().ToList());
            return View(posts);
        }

        // GET: Administration/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = Data.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Administration/Posts/Create
        public ActionResult Create()
        {
            PostViewModel postVM = new PostViewModel();
            postVM.Users = new SelectList(Data.Users.All(), "Id", "Email");
            return View(postVM);
        }

        // POST: Administration/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,AuthorId,CreatedOn,IsDeleted")] Post post)
        {
            if (ModelState.IsValid)
            {
                Data.Posts.Add(post);
                Data.Posts.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(Data.Users.All(), "Id", "Email", post.AuthorId);
            return View(post);
        }

        // GET: Administration/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = Data.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(Data.Users.All(), "Id", "Email", post.AuthorId);
            return View(post);
        }

        // POST: Administration/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,AuthorId,CreatedOn,IsDeleted")] Post post)
        {
            if (ModelState.IsValid)
            {
                Data.Posts.Update(post);
                Data.Posts.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(Data.Users.All(), "Id", "Email", post.AuthorId);
            return View(post);
        }

        // GET: Administration/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = Data.Posts.Find(id);
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
            Post post = Data.Posts.Find(id);
            Data.Posts.Delete(post);
            Data.Posts.SaveChanges();
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
