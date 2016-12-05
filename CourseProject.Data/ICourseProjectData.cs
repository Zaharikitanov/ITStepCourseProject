namespace CourseProject.Data
{
    using CourseProject.Data.Repositories;
    using CourseProject.Models;

    public interface ICourseProjectData
    {
        IRepository<ApplicationUser> Users
        {
            get;
        }

        IRepository<Post> Posts
        {
            get;
        }

        IRepository<T> GetRepository<T>() where T : class;
    }
}
