namespace ElasticBlog.Application.DomainEventHandlers
{
    public class CategoryStatusChangedToPassiveDomainEventHandler : INotificationHandler<CategoryStatusChangedToPassiveDomainEvent>
    {
        public async Task Handle(CategoryStatusChangedToPassiveDomainEvent notification, CancellationToken cancellationToken)
        {
            //TODO: ElasticSearch'te ilgili kategoriye ait postlar silinmesi
        }
    }
}

