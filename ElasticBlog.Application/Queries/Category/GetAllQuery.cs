using ElasticBlog.Application.Models.ResponseModels.Category;

namespace ElasticBlog.Application.Queries.Category
{
    public class GetAllQuery : IRequest<BaseResponse>
    {
    }

    public class GetAllQueryHandler : BaseCategoryQuery, IRequestHandler<GetAllQuery, BaseResponse>
    {
        public GetAllQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
            : base(mapper, categoryRepository)
        {
        }

        public async Task<BaseResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllActiveRecordsAsync();
            var responseModel = _mapper.Map<List<GetAllCategoryResponseModel>>(categories);
            return BaseResponse.Success(responseModel);
        }
    }
}

