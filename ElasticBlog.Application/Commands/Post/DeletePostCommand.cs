namespace ElasticBlog.Application.Commands.Post
{
    public class DeletePostCommand : IRequest<BaseResponse>
    {
        public int Id { get; private set; }

        public DeletePostCommand(int id)
        {
            Id = id;
        }
    }

    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator()
        {
            RuleFor(f => f.Id).GreaterThan(0).WithMessage("Post Id'si sıfırdan büyük olmalıdır");
        }
    }

    public class DeletePostCommandHandler : BasePostCommand, IRequestHandler<DeletePostCommand, BaseResponse>
    {
        public DeletePostCommandHandler(IMapper mapper, IPostRepository postRepository) : base(mapper, postRepository)
        {
        }

        public async Task<BaseResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = await _postRepository.GetByIdAsync(request.Id);
            if (post == null)
                return BaseResponse.Fail(new NoContent());
            post.SetStatusChangedToPassive();
            _postRepository.Update(post);
            await _postRepository.UnitOfWork.CompleteTransaction();
            return BaseResponse.Success(new NoContent());
        }
    }
}

