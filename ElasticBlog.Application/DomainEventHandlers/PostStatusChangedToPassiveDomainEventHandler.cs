using ElasticBlog.Persistence.Search.Elastic.Interfaces;

namespace ElasticBlog.Application.DomainEventHandlers
{
    public class PostStatusChangedToPassiveDomainEventHandler : INotificationHandler<PostStatusChangedToPassiveDomainEvent>
    {
        private IElasticClient<Domain.ElasticModel.Post> _elasticClient;

        public PostStatusChangedToPassiveDomainEventHandler(IElasticClient<Domain.ElasticModel.Post> elasticClient)
        {
            _elasticClient = elasticClient;
        }

        public async Task Handle(PostStatusChangedToPassiveDomainEvent notification, CancellationToken cancellationToken)
        {
            var response = await _elasticClient.Delete(q => q.Query(rq => rq.Match(m => m.Field(f => f.Id).Query(notification.Post.Id.ToString()))).Index("posts"));
            if (!response.IsValid) throw new Exception();
        }
    }
}

