
namespace CourseProjectServices
{
    using CourseProjectServices.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CourseProject.Data;

    public class PostService : BaseService, IPostService
    {
        public PostService(ICourseProjectData data) 
            :base(data)
        {

        }

        public IQueryable<Post> GetAll()
        {
            this.Data.Posts.All();
        }

        public Post Find(int id)
        {
            return this.Data.Posts.Find(id);
        }
    }
}
