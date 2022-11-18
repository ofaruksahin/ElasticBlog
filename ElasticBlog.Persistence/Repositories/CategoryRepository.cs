namespace ElasticBlog.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ElasticBlogDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> AnyExists(string name)
        {
            return await _dbContext.Categories
                .AnyAsync(f =>
                    f.Status == Domain.Shared.Enumerations.EnumRecordStatus.Active &&
                    f.Name == name);
        }
    }
}
