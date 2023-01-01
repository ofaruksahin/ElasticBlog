using ElasticBlog.Domain.DomainEvents;

namespace ElasticBlog.Domain.Models
{
    public class Post : BaseEntity
    {
        public int CategoryId { get; private set; }
        public string Title { get; set; }
        public string Content { get; set; }

        private Category _category;
        public virtual Category Category => _category;

        private List<Tag> _tags;
        public IReadOnlyList<Tag> Tags => _tags;

        protected Post()
        {
        }

        public Post(int categoryId, string title, string content)
        {
            CategoryId = categoryId;
            Title = title;
            Content = content;

            _tags = new List<Tag>();
        }

        public static Post Create(int categoryId, string title, string content)
        {
            var post = new Post(categoryId, title, content);
            post.AddDomainEvent(new PostCreatedDomainEvent(post));
            return post;
        }

        public void AddTag(string tag)
        {
            if (_tags == null)
                _tags = new List<Tag>();

            var exists = _tags.Any(f => string.Equals(f.Name, tag, StringComparison.InvariantCultureIgnoreCase));
            if (exists)
                return;
            var tagModel = Tag.Create(tag);
            tagModel.SetCreatedDate();
            _tags.Add(tagModel);
        }
    }
}
