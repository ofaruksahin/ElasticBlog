using ElasticBlog.Persistence.Search.Elastic.Interfaces;

namespace ElasticBlog.Application.DomainEventHandlers
{
    public class CategoryStatusChangedToPassiveDomainEventHandler : INotificationHandler<CategoryStatusChangedToPassiveDomainEvent>
    {
        private IElasticClient<Domain.ElasticModel.Post> _elasticClient;

        public CategoryStatusChangedToPassiveDomainEventHandler(IElasticClient<Domain.ElasticModel.Post> elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task Handle(CategoryStatusChangedToPassiveDomainEvent notification, CancellationToken cancellationToken)
        {
            var response = await _elasticClient.Delete(q => q.Query(rq => rq.Match(m => m.Field(f => f.CategoryId).Query(notification.Category.Id.ToString()))).Index("posts"));
            if (!response.IsValid) throw new Exception();
        }
    }
}

