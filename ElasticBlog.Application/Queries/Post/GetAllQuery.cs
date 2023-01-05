using ElasticBlog.Application.Models.ResponseModels.Post;

namespace ElasticBlog.Application.Queries.Post
{
    public class GetAllQuery : IRequest<BaseResponse>
    {
    }

    public class GetAllQueryHandler : BasePostQuery, IRequestHandler<GetAllQuery, BaseResponse>
    {
        public GetAllQueryHandler(IPostRepository postRepository, IMapper mapper)
            : base(postRepository, mapper)
        {
        }

        public async Task<BaseResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var elasticResponse = await _postRepository.GetPostsFromElastic();
            var responseModel = _mapper.Map<List<GetAllPostResponseModel>>(elasticResponse);
            return BaseResponse.Success(responseModel);
        }
    }
}

