namespace ElasticBlog.Application.DomainEventHandlers
{
    public class PostCreatedDomainEventHandler : INotificationHandler<PostCreatedDomainEvent>
    {
        public async Task Handle(PostCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
           //TODO: Db'yi eklenen post bilgisini elasticsearch indexlemek gerekmekte
        }
    }
}
