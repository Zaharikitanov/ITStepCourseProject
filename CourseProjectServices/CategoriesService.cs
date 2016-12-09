
namespace CourseProjectServices
{
    using Contracts;
    using CourseProject.Data;
    using CourseProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class CategoriesService : BaseService<Category>, ICategoryService
    {

        public CategoriesService(ICourseProjectData data) 
            :base(data)
        {

        }

        public override IQueryable<Category> GetAll()
        {
            return base.GetAll();
        }

        public override void Add(Category entity)
        {
            entity.CreatedOn = DateTime.Now;
            base.Add(entity);
            base.SaveChanges();
        }

        
    }
}
