namespace ElasticBlog.Application.Commands.Category
{
    public class BaseCategoryCommand : BaseCommand
    {
        protected ICategoryRepository _categoryRepository;

        public BaseCategoryCommand(IMapper mapper,ICategoryRepository categoryRepository) : base(mapper)
        {
            _categoryRepository = categoryRepository;
        }
    }
}

