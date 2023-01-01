namespace ElasticBlog.Domain.IRepositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task AddElastic(Post post);
    }
}
