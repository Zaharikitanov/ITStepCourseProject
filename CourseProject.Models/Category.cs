
namespace CourseProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Category : BaseModel
    {
        public string Title { get; set; }

        public string AuthorId { get; set; }
    }
}
