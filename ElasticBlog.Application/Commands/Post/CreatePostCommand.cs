using ElasticBlog.Application.Models.RequestModels.Post;
using ElasticBlog.Application.Models.ResponseModels.Post;

namespace ElasticBlog.Application.Commands.Post
{
    public class CreatePostCommand : IRequest<BaseResponse>
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<TagRequestModel> Tags { get; set; }

        public CreatePostCommand()
        {
            Tags = new List<TagRequestModel>();
        }
    }

    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(f => f.CategoryId).GreaterThan(0).WithMessage("Kategori Id'si 0'dan büyük olmalıdır");
            RuleFor(f => f.Title).NotEmpty().WithMessage("İçerik başlığı boş olmamalıdır");
            RuleFor(f => f.Title).MaximumLength(100).WithMessage("İçerik başlığı 100 karakterden boş olmamalıdır");
            RuleFor(f => f.Content).NotEmpty().WithMessage("İçerik boş olamaz");
            When(f => f.Tags != null && f.Tags.Any(), () =>
            {
                RuleForEach(f => f.Tags).ChildRules(tag =>
                {
                    tag.RuleFor(f => f.Name).NotEmpty().WithMessage("İçerik tag'i boş olmamalıdır");
                    tag.RuleFor(f => f.Name).MaximumLength(100).WithMessage("İçerik tag'i 100 karakterden fazla olamaz");
                });
            });
        }
    }

    public class CreatePosCommandHandler : BasePostCommand, IRequestHandler<CreatePostCommand, BaseResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreatePosCommandHandler(
            IMapper mapper,
            IPostRepository postRepository,
            ICategoryRepository categoryRepository)
            : base(mapper, postRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken) 
        {
            var category = await _categoryRepository.GetByIdActiveRecordAsync(request.CategoryId);
            if (category == null)
                return BaseResponse.Fail(new NoContent(), "Kategori bulunamadı");
            var post = Domain.Models.Post.Create(request.CategoryId, request.Title, request.Content);
            request.Tags.ForEach(tag => post.AddTag(tag.Name));
            await _postRepository.AddAsync(post);
            await _postRepository.UnitOfWork.CompleteTransaction();
            var responseModel = _mapper.Map<CreatedPostResponseModel>(post);
            return BaseResponse.Success(responseModel);
        }
    }
}

