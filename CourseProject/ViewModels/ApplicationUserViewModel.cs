

namespace CourseProject.ViewModels
{
    using Common.Mapping;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class ApplicationUserViewModel : IMapFrom<ApplicationUser>
    {
        public string UserName { get; set; }

    }
}