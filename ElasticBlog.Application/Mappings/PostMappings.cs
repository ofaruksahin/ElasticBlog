using ElasticBlog.Application.Models.ResponseModels.Post;

namespace ElasticBlog.Application.Mappings
{
    public class PostMappings : Profile
    {
        public PostMappings()
        {
            CreateMap<Post, CreatedPostResponseModel>()
                .ForMember(f => f.Id, f => f.MapFrom(f => f.Id));
        }
    }
}

