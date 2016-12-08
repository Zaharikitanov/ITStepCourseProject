
namespace CourseProject.Areas.Administration.ViewModels
{
    using CourseProject.Common.Mapping;
    using CourseProject.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class PostViewModel : IMapFrom<Post>, IMapTo<Post>
    {
        public int Id { get; set; }

        [Display(Name = "Title content")]
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }
        public string Content { get; set; }
        public ApplicationUserViewModel Author { get; set; }
        public DateTime? CreatedOn { get; set; }

        [Required]
        public string AuthorId { get; set; }
        public SelectList Users { get; set; }

        public string ShortenedContent (string text)
        {
            string shortenedText;
            int MaxLength = 50;

            if (text.Length >= MaxLength)
            {
                shortenedText = text.Substring(0, MaxLength) + "...";
            }
            else
            {
                shortenedText = text;
            }
            return shortenedText;
        }
    }
}