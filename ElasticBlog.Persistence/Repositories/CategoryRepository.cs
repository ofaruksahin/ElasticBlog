namespace ElasticBlog.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ElasticBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
