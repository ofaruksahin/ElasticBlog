namespace ElasticBlog.Application.Commands.Category
{
    public class UpdateCategoryCommand : IRequest<BaseResponse>
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public UpdateCategoryCommand(int id,string name)
        {
            Id = id;
            Name = name;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }

    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(f => f.Id).GreaterThan(0).WithMessage("Kategori Id'si 0'dan büyük olmalıdır");
            RuleFor(f => f.Name).NotEmpty().WithMessage("Kategori adı boş olmamalıdır");
            RuleFor(f => f.Name).MaximumLength(100).WithMessage("Kategori adı 100 karakterden fazla olamaz");
        }
    }

    public class UpdateCategoryCommandHandler : BaseCategoryCommand, IRequestHandler<UpdateCategoryCommand, BaseResponse>
    {
        public UpdateCategoryCommandHandler(IMapper mapper, ICategoryRepository categoryRepository)
            : base(mapper, categoryRepository)
        {
        }

        public async Task<BaseResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdActiveRecordAsync(request.Id);
            if (category == null)
                return BaseResponse.Fail(new NoContent());
            category.ChangeName(request.Name);
            _categoryRepository.Update(category);
            await _categoryRepository.UnitOfWork.CompleteTransaction();
            return BaseResponse.Success(new NoContent());
        }
    }
}

