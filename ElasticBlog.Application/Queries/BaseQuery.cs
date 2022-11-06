namespace ElasticBlog.Application.Queries
{
    public class BaseQuery
    {
        protected IMapper _mapper;

        public BaseQuery(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
    }
}
