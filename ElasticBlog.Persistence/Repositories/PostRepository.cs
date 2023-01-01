using ElasticBlog.Persistence.Search.Elastic.Interfaces;

namespace ElasticBlog.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private ICategoryRepository _categoryRepository;
        private IElasticClient<Search.Elastic.Models.Post> _elasticClient;

        public PostRepository(
            ElasticBlogDbContext dbContext,
            ICategoryRepository categoryRepository,
            IElasticClient<Search.Elastic.Models.Post> elasticClient)
            : base(dbContext)
        {
            _categoryRepository = categoryRepository;
            _elasticClient = elasticClient;
        }

        public async Task AddElastic(Post post)
        {
            var category = await _categoryRepository.GetByIdActiveRecordAsync(post.CategoryId);
            if (category == null) return;
            Search.Elastic.Models.Post elasticModel = new Search.Elastic.Models.Post
            {
                CategoryId = post.CategoryId,
                CategoryName = category.Name,
                Title = post.Title,
                Content = post.Content,
                Tags = post.Tags.Select(f=>f.Name).ToList()
            };

            await _elasticClient.CreateIndex("posts",f=>
                f.Map<Search.Elastic.Models.Post>(y=>y.AutoMap()));

            await _elasticClient.Index(elasticModel, "posts");
        }
    }
}
