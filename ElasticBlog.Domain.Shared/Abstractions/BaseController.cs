namespace ElasticBlog.Domain.Shared.Abstractions
{
    [ApiController]
    [Route("/api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [NonAction]
        public IActionResult Response(BaseResponse response)
            => new OkObjectResult(response)
            {
                StatusCode = response.StatusCode
            };
    }
}
