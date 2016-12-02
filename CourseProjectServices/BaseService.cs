
namespace CourseProjectServices
{
    using CourseProject.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class BaseService
    {
        public BaseService(ICourseProjectData data)
        {
            this.Data = data;
        }
        protected ICourseProjectData Data { get; private set; }
    }
}
