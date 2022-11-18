using ElasticBlog.Application.Commands.Category;
using ElasticBlog.Application.Models.RequestModels.Category;
using ElasticBlog.Application.Models.ResponseModels.Category;

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
    }
}

