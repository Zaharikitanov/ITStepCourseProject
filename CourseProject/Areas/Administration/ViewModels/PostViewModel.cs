
namespace CourseProject.Areas.Administration.ViewModels
{
    using CourseProject.Common.Mapping;
    using CourseProject.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class PostViewModel : IMapFrom<Post>, IMapTo<Post>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ApplicationUserViewModel Author { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string AuthorId { get; set; }
        public SelectList Users { get; set; }
    }
}