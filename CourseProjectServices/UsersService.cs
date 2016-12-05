
namespace CourseProjectServices
{
    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CourseProject.Models;
    using CourseProject.Data;
    public class UsersService : BaseService<ApplicationUser>, IUsersService
    {
        public UsersService(ICourseProjectData data)
            : base(data)
        {

        }
    }
}
