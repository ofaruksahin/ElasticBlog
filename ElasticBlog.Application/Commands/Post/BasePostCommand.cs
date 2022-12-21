namespace ElasticBlog.Application.Commands.Post
{
    public class BasePostCommand : BaseCommand
    {
        protected IPostRepository _postRepository;

        public BasePostCommand(IMapper mapper,IPostRepository postRepository) : base(mapper)
        {
            _postRepository = postRepository;
        }
    }
}

