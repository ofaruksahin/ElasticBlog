using ElasticBlog.Application.Models.ResponseModels.Category;

namespace ElasticBlog.Application.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CreatedCategoryResponseModel>()
                .ForMember(f => f.Id, f => f.MapFrom(f => f.Id));
        }
    }
}

