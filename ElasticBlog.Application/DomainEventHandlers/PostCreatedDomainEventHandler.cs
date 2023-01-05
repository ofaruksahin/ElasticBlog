namespace ElasticBlog.Application.DomainEventHandlers
{
    public class PostCreatedDomainEventHandler : INotificationHandler<PostCreatedDomainEvent>
    {
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;

        public PostCreatedDomainEventHandler(
            ICategoryRepository categoryRepository,
            IPostRepository postRepository)
        {
            _categoryRepository = categoryRepository;
            _postRepository = postRepository;
        }

        public async Task Handle(PostCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(notification.Post.CategoryId);
            if (category == null)
                throw new Exception("İlgili kategori bulunamadı");
            var elasticModel = new Domain.ElasticModel.Post
            {
                Id = notification.Post.Id,
                CategoryId = notification.Post.CategoryId,
                CategoryName = category.Name,
                Title = notification.Post.Title,
                Content = notification.Post.Content,
                Tags = notification.Post.Tags.Select(f => f.Name).ToList()
            };
            await _postRepository.AddAsync(elasticModel);
        }
    }
}
