using ElasticBlog.Application.Models.RequestModels.Category;
using ElasticBlog.Application.Models.ResponseModels.Category;
using Categ = ElasticBlog.Domain.Models.Category;

namespace ElasticBlog.Application.Commands.Category
{
    public class CreateCategoryCommand : CreateCategoryRequestModel, IRequest<BaseResponse>
    {
        public CreateCategoryCommand(string name)
        {
            Name = name;
        }
    }

    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(f => f.Name).NotEmpty().MaximumLength(100);
        }
    }

    public class CreateCategoryCommandHandler : BaseCategoryCommand, IRequestHandler<CreateCategoryCommand, BaseResponse>
    {
        public CreateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository) : base(mapper, categoryRepository)
        {
        }

        public async Task<BaseResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var hasAny = await _categoryRepository.AnyExists(request.Name);
            if (hasAny)
                return BaseResponse.Fail(new NoContent(), BaseConstants.AlreadyExistsRecord, StatusCodes.Status404NotFound);
            var category = Categ.Create(request.Name);
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.UnitOfWork.CompleteTransaction();
            var responseModel = _mapper.Map<CreatedCategoryResponseModel>(category);
            return BaseResponse.Success(responseModel, StatusCodes.Status200OK);
        }
    }
}

