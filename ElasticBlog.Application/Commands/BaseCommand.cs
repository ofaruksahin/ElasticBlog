namespace ElasticBlog.Application.Commands
{
    public abstract class BaseCommand
    {
        protected IMapper _mapper;

        protected BaseCommand(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
