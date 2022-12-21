using ElasticBlog.Application.Models.RequestModels.Post;

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
            return BaseResponse.Success(new NoContent());
        }
    }
}

