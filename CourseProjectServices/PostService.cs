
namespace CourseProjectServices
{
    using CourseProjectServices.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CourseProject.Data;

    public class PostService : BaseService<Post>, IPostService
    {
        public PostService(ICourseProjectData data) 
            :base(data)
        {

        }
    }
}
