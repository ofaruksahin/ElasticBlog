using ElasticBlog.Domain.DomainEvents;

namespace ElasticBlog.Domain.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }

        private List<Post> _posts;
        public IReadOnlyList<Post> Posts => _posts;

        protected Category()
        {
        }

        public Category(string name)
        {
            Name = name;

            _posts = new List<Post>();
        }

        public static Category Create(string name)
            => new Category(name);

        public void StatusChangedToPassive()
        {
            Status = EnumRecordStatus.Passive;
            AddDomainEvent(new CategoryStatusChangedToPassiveDomainEvent(this));
        }

        public void ChangeName(string name)
        {
            Name = name;
        }
    }
}
