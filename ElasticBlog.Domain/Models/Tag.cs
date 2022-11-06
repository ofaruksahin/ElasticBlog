namespace ElasticBlog.Domain.Models
{
    public class Tag : BaseEntity
    {
        public string Name { get; private set; }

        public int PostId { get; private set; }

        private Post _post;
        public virtual Post Post => _post;

        public Tag(string name)
        {
            Name = name;
        }

        public static Tag Create(string name)
            => new Tag(name);
    }
}
