﻿
namespace CourseProject.ViewModels
{
    using CourseProject.Common.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    public class PostViewModel : IMapFrom<Post>, IMapTo<Post>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ApplicationUserViewModel Author { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}