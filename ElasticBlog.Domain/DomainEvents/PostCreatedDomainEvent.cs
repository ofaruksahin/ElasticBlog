namespace ElasticBlog.Domain.DomainEvents
{
    public class PostCreatedDomainEvent : INotification
    {
        public Post Post { get; private set; }

        public PostCreatedDomainEvent(Post post)
        {
            Post = post;
        }
    }
}
