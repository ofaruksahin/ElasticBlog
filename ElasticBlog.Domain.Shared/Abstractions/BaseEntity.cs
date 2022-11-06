namespace ElasticBlog.Domain.Shared.Abstractions
{
    public class BaseEntity
    {
        public int Id { get; protected set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime? LastModifiedDate { get; private set; }

        public EnumRecordStatus Status { get; set; }

        protected BaseEntity()
        {
            Status = EnumRecordStatus.Active;
        }

        private List<INotification> _domainEvents;
        public IReadOnlyList<INotification> DomainEvents
        {
            get => _domainEvents ?? new List<INotification>();
        }

        public void AddDomainEvent(INotification domainEvent)
        {
            if (_domainEvents is null)
                _domainEvents = new List<INotification>();

            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            if (_domainEvents is null)
                _domainEvents = new List<INotification>();

            _domainEvents.Clear();
        }

        public void SetCreatedDate()
        {
            CreatedDate = DateTime.Now;
        }

        public void SetLastModifiedDate()
        {
            LastModifiedDate = DateTime.Now;
        }
    }
}
