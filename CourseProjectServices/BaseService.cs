
namespace CourseProjectServices
{
    using Contracts;
    using CourseProject.Data;
    using CourseProject.Data.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Services.Description;
    public class BaseService<T> : IService<T> where T : class
    {
        private IRepository<T> repository;
        public BaseService(ICourseProjectData data)
        {
            this.Data = data;
            this.repository = data.GetRepository<T>();
        }
        protected ICourseProjectData Data { get; private set; }

        public IQueryable<T> GetAll()
        {
            return this.repository.All();
        }

        public T Find(object id)
        {
            return this.repository.Find(id);
        }

        public void Add (T entity)
        {
            this.repository.Add(entity);
        }

        public void Update (T entity)
        {
            this.repository.Update(entity);
        }

        public void SaveChanges (T entity)
        {
            this.repository.SaveChanges();
        }

        public void Delete (T entity)
        {
            this.repository.Delete(entity);
        }
    }
}
