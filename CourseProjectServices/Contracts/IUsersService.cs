
namespace CourseProjectServices.Contracts
{
    using CourseProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface IUsersService
    {
        IQueryable<ApplicationUser> GetAll();
    }
}
