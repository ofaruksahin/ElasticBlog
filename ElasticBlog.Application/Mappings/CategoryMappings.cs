using ElasticBlog.Application.Models.ResponseModels.Category;

namespace ElasticBlog.Application.Mappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, CreatedCategoryResponseModel>()
                .ForMember(f => f.Id, f => f.MapFrom(f => f.Id));

            CreateMap<Category, GetAllCategoryResponseModel>()
                .ForMember(f => f.Id, f => f.MapFrom(f => f.Id))
                .ForMember(f => f.Name, f => f.MapFrom(f => f.Name));

            CreateMap<Category, GetQueryResponseModel>()
                .ForMember(f => f.Id, f => f.MapFrom(f => f.Id))
                .ForMember(f => f.Name, f => f.MapFrom(f => f.Name));
        }
    }
}

