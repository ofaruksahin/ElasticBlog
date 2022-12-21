using ElasticBlog.Application.Models.ResponseModels.Category;

namespace ElasticBlog.Application.Queries.Category
{
    public class GetQuery : IRequest<BaseResponse>
    {
        public int Id { get; private set; }

        public GetQuery(int id)
        {
            Id = id;
        }
    }

    public class GetQueryValidator : AbstractValidator<GetQuery>
    {
        public GetQueryValidator()
        {
            RuleFor(f => f.Id).GreaterThan(0).WithMessage("Kategori Id'si 0'dan büyük olmalıdır");
        }
    }

    public class GetQueryHandler : BaseCategoryQuery, IRequestHandler<GetQuery, BaseResponse>
    {
        public GetQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
            : base(mapper, categoryRepository)
        {
        }

        public async Task<BaseResponse> Handle(GetQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdActiveRecordAsync(request.Id);
            if (category == null)
                return BaseResponse.Fail(new NoContent());
            var responseModel = _mapper.Map<GetQueryResponseModel>(category);
            return BaseResponse.Success(responseModel);
        }
    }
}

