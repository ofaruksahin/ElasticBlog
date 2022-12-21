namespace ElasticBlog.Application.Queries.Category
{
    public class BaseCategoryQuery : BaseQuery
    {
        protected readonly ICategoryRepository _categoryRepository;

        public BaseCategoryQuery(
            IMapper mapper,
            ICategoryRepository categoryRepository) : base(mapper)
        {
            _categoryRepository = categoryRepository;
        }
    }
}

