using ElasticBlog.Application.Commands.Post;
using ElasticBlog.Application.Models.ResponseModels.Post;
using ElasticBlog.Application.Queries.Post;

namespace ElasticBlog.API.Controllers
{
    public class PostsController : BaseController
    {
        public PostsController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Post oluşturmak için kullanılır
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

        /// <summary>
        /// Postları getirmek için kullanılır
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<List<GetAllPostResponseModel>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAll()
        {
            var request = new GetAllQuery();
            var response = await _mediator.Send(request);
            return Response(response);
        }

        /// <summary>
        /// Postu silmek için kullanılır
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var request = new DeletePostCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }
    }
}

