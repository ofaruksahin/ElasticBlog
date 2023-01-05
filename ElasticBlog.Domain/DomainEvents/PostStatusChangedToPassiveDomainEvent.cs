namespace ElasticBlog.Domain.DomainEvents
{
    public class PostStatusChangedToPassiveDomainEvent : INotification
    {
        public Post Post { get; private set; }

        public PostStatusChangedToPassiveDomainEvent(Post post)
        {
            Post = post;
        }
    }
}

