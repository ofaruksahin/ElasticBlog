namespace ElasticBlog.Application.Queries.Post
{
    public class BasePostQuery : BaseQuery
    {
        protected IPostRepository _postRepository;

        public BasePostQuery(
            IPostRepository postRepository,
            IMapper mapper)
            : base(mapper)
        {
            _postRepository = postRepository;
        }
    }
}

