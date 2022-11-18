namespace ElasticBlog.Domain.IRepositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<bool> AnyExists(string name);
    }
}
