using ElasticBlog.Application.Commands.Post;
using ElasticBlog.Application.Models.ResponseModels.Post;

namespace ElasticBlog.API.Controllers
{
    public class PostsController : BaseController
    {
        public PostsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Pos oluşturmak için kullanılır
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<CreatedPostResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreatePostCommand request)
        {
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

