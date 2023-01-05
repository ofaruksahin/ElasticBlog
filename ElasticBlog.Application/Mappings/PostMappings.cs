using ElasticBlog.Application.Models.ResponseModels.Post;

namespace ElasticBlog.Application.Mappings
{
    public class PostMappings : Profile
    {
        public PostMappings()
        {
            CreateMap<Post, CreatedPostResponseModel>()
                .ForMember(f => f.Id, f => f.MapFrom(f => f.Id));

            CreateMap<Domain.ElasticModel.Post, GetAllPostResponseModel>()
                .ForMember(f => f.Id, f => f.MapFrom(f => f.Id))
                .ForMember(f => f.CategoryId, f => f.MapFrom(f => f.CategoryId))
                .ForMember(f => f.CategoryName, f => f.MapFrom(f => f.CategoryName))
                .ForMember(f => f.Title, f => f.MapFrom(f => f.Title))
                .ForMember(f => f.Content, f => f.MapFrom(f => f.Content))
                .ForMember(f => f.Tags, f => f.MapFrom(f => f.Tags));
        }
    }
}

