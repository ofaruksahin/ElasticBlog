namespace ElasticBlog.Domain.IRepositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task AddAsync(Domain.ElasticModel.Post post);
        Task<List<Domain.ElasticModel.Post>> GetPostsFromElastic();
    }
}
