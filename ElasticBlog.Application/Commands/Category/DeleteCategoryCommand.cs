namespace ElasticBlog.Application.Commands.Category
{
    public class DeleteCategoryCommand : IRequest<BaseResponse>
    {
        public int Id { get; private set; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(f => f.Id).GreaterThan(0).WithMessage("Kategori Id'si 0'dan büyük olmalıdır");
        }
    }

    public class DeleteCategoryCommandHandler : BaseCategoryCommand, IRequestHandler<DeleteCategoryCommand, BaseResponse>
    {
        public DeleteCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
            : base(mapper, categoryRepository)
        {
        }

        public async Task<BaseResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdActiveRecordAsync(request.Id);
            if (category == null)
                return BaseResponse.Fail(new NoContent());
            category.StatusChangedToPassive();
            _categoryRepository.Update(category);
            await _categoryRepository.UnitOfWork.CompleteTransaction();
            return BaseResponse.Success(new NoContent());
        }
    }
}

