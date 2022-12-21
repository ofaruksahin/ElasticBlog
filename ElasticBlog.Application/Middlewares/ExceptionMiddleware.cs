using ElasticBlog.Domain.ValueObjects;

namespace ElasticBlog.Application.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private IElasticLogger _logger;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context,IElasticLogger logger)
        {
            try
            {
                _logger = logger;
                await _next(context);
            }catch(FluentValidationException ex)
            {
                await WriteResponse(context, new NoContent(), ex.Errors, StatusCodes.Status400BadRequest);
            }catch(Exception ex)
            {
                Exception _ex = ex;
                if (ex.InnerException != null)
                    _ex = ex.InnerException;
                await WriteResponse(context, new NoContent(), new List<string> { _ex.Message }, StatusCodes.Status500InternalServerError);
            }
        }

        private async Task WriteResponse(HttpContext context, object data = null, List<string> message = null, int statusCode = 500)
        {
            await LogElastic(context,message);
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = statusCode;

            var baseResponse = BaseResponse.Fail(data, message, statusCode);
            var json = JsonSerializer.Serialize(baseResponse);

            await response.WriteAsync(json);
        }

        private async Task LogElastic(HttpContext context,List<string> message)
        {
            if (message == null)
                message = new List<string>();
            var paths = context.Request.Path.ToString().Split('/').ToList();
            paths.RemoveAll(f => string.IsNullOrEmpty(f));
            string controllerName = string.Empty;
            string actionName = string.Empty;
            if (paths.Count >= 1)
                controllerName = paths[0];
            if (paths.Count >= 2)
                actionName = paths[1];

            var logModel = new LogModel(DateTime.Now,$"{controllerName}/{actionName}", string.Join("\n", message));
            await _logger.LogException(logModel);
        }
    }
}
