using ElasticBlog.Application.Exceptions;
using ElasticBlog.Domain.Shared.Response;

namespace ElasticBlog.Application.Pipelines
{
    public class FluentValidationPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : BaseResponse
    {
        private IServiceProvider _serviceProvider;

        public FluentValidationPipeline(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var validator = _serviceProvider.GetService(typeof(IValidator<TRequest>));
            if (validator != null && validator is IValidator<TRequest> requestValidator)
            {
                var validationResult = requestValidator.Validate(request);
                if (!validationResult.IsValid)
                    throw new FluentValidationException(validationResult.Errors);
            }

            return await next();
        }
    }
}
