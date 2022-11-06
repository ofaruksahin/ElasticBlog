namespace ElasticBlog.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(ElasticBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
