namespace ElasticBlog.Application.DomainEventHandlers
{
    public class PostCreatedDomainEventHandler : INotificationHandler<PostCreatedDomainEvent>
    {
        private IPostRepository _postRepository;

        public PostCreatedDomainEventHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task Handle(PostCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _postRepository.AddElastic(notification.Post);
        }
    }
}
