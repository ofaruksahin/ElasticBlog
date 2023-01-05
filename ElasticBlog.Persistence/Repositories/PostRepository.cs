using ElasticBlog.Persistence.Search.Elastic.Interfaces;

namespace ElasticBlog.Persistence.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private IElasticClient<Domain.ElasticModel.Post> _elasticClient;

        public PostRepository(
            ElasticBlogDbContext dbContext,
            IElasticClient<Domain.ElasticModel.Post> elasticClient)
            : base(dbContext)
        {
            _elasticClient = elasticClient;
        }

        public async Task AddAsync(Domain.ElasticModel.Post post)
        {
            await _elasticClient.CreateIndex("posts", f => f.Map<Domain.ElasticModel.Post>(y => y.AutoMap()));
            var response = await _elasticClient.Index(post, "posts");
            if (!response.IsValid) throw new Exception();
        }

        public async Task<List<Domain.ElasticModel.Post>> GetPostsFromElastic()
        {
            var responses = await _elasticClient.Search(f => f.Index("posts").MatchAll());
            return responses.Hits.Select(f => new Domain.ElasticModel.Post
            {
                Id = f.Source.Id,
                CategoryId = f.Source.CategoryId,
                CategoryName = f.Source.CategoryName,
                Title = f.Source.Title,
                Content = f.Source.Content,
                Tags = f.Source.Tags
            }).ToList();
        }
    }
}
