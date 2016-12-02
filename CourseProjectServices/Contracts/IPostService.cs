using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseProjectServices.Contracts
{
    public interface IPostService
    {
        IQueryable<Post> GetAll();
    }
}
