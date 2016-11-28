namespace CourseProject.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using CourseProject.Models;

    public class CourseProjectDbContext : IdentityDbContext
    {
        public CourseProjectDbContext()
            : base("CourseProjectConnection")
        {
            
        }

        public IDbSet<ApplicationUser> Users
        {
            get;
            set;
        }

        public IDbSet<Post> Posts
        {
            get;
            set;
        }

        public static CourseProjectDbContext Create()
        {
            return new CourseProjectDbContext();
        }
    }
}