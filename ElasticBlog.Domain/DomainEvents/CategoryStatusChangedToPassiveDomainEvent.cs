namespace ElasticBlog.Domain.DomainEvents
{
    public class CategoryStatusChangedToPassiveDomainEvent : INotification
    {
        public Category Category { get; private set; }

        public CategoryStatusChangedToPassiveDomainEvent(Category category)
        {
            Category = category;
        }
    }
}

