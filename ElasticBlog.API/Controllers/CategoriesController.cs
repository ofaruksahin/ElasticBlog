using ElasticBlog.Application.Commands.Category;
using ElasticBlog.Application.Models.RequestModels.Category;
using ElasticBlog.Application.Models.ResponseModels.Category;
using ElasticBlog.Application.Queries.Category;

namespace ElasticBlog.API.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Kategori oluşturmak için kullanılır.
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(BaseResponse<CreatedCategoryResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CreateCategoryRequestModel requestModel)
        {
            var request = new CreateCategoryCommand(requestModel.Name);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        /// <summary>
        /// Kategorileri getirmek için kullanılır.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(BaseResponse<List<GetAllResponseModel>>),StatusCodes.Status200OK)]
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
        /// Kategoriyi getirmek için kullanılır.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BaseResponse<GetQueryResponseModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetQuery(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        /// <summary>
        /// Kategori silmek için kullanılır
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
            var request = new DeleteCategoryCommand(id);
            var response = await _mediator.Send(request);
            return Response(response);
        }

        /// <summary>
        /// Kategori güncellemek için kullanılır
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(BaseResponse<NoContent>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id,[FromBody]UpdateCategoryCommand command)
        {
            command.SetId(id);
            var response = await _mediator.Send(command);
            return Response(response);
        }
    }
}

