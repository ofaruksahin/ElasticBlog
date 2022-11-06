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

        public Post(int categoryId, string title, string content)
        {
            CategoryId = categoryId;
            Title = title;
            Content = content;

            _tags = new List<Tag>();
        }

        public static Post Create(int categoryId, string title, string content)
            => new Post(categoryId, title, content);
    }
}
