
namespace CourseProject.Areas.Administration.ViewModels
{
    using CourseProject.Common.Mapping;
    using CourseProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class CategoriesViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public SelectList Users { get; set; }

        public string AuthorId { get; set; }
    }
}