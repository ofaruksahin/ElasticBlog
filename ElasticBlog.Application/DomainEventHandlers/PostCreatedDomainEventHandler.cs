namespace ElasticBlog.Application.DomainEventHandlers
{
    public class PostCreatedDomainEventHandler : INotificationHandler<PostCreatedDomainEvent>
    {
        public async Task Handle(PostCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
           
        }
    }
}
