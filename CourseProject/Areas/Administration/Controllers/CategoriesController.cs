
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
    using Models;
    public class CategoriesController : BaseController
    {
        private CourseProjectDbContext db = new CourseProjectDbContext();

        private ICategoryService categoriesService;
        private IUsersService usersService;
        public CategoriesController(ICategoryService categoryService, IUsersService userService)
        {
            this.categoriesService = categoryService;
            this.usersService = userService;
        }
        // GET: Administration/Posts
        public ActionResult Index()
        {
            var categories = Mapper.Map<List<Category>,
                List<CategoriesViewModel>>(categoriesService.GetAll().ToList());
            return View(categories);
        }

        // GET: Administration/Posts/Create
        public ActionResult Create()
        {
            CategoriesViewModel categoryVM = new CategoriesViewModel();
            categoryVM.Users = new SelectList(this.usersService.GetAll(), "Id", "Email");
            return View(categoryVM);
        }

        // POST: Administration/Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create(CategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = Mapper.Map<Category>(category);
                this.categoriesService.Add(dbCategory);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(this.categoriesService.GetAll(), "Id", "Email", category.AuthorId);
            return View(category);
        }

        [ValidateInput(false)]
        // GET: Administration/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.categoriesService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            CategoriesViewModel categoryVM = Mapper.Map<CategoriesViewModel>(category);
            categoryVM.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", category.AuthorId);
            return View(categoryVM);
        }

        // POST: Administration/Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(CategoriesViewModel category)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = Mapper.Map<Category>(category);
                this.categoriesService.Update(dbCategory);
                return RedirectToAction("Index");
            }
            category.Users = new SelectList(this.usersService.GetAll(), "Id", "Email", category.AuthorId);
            return View(category);
        }

        // GET: Administration/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = this.categoriesService.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Administration/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            this.categoriesService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}