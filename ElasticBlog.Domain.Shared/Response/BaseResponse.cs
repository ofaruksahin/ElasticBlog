namespace ElasticBlog.Domain.Shared.Response
{
    public class BaseResponse
    {
        public object Data { get; private set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }
        public List<string> Messages { get; private set; } = new List<string>();
        [JsonIgnore]
        public bool IsSuccess { get; private set; }

        public static BaseResponse Success(object data, int statusCode = (int)HttpStatusCode.OK)
            => new BaseResponse
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = true,
                Messages = new List<string>()
            };

        public static BaseResponse Success(object data, string message, int statusCode = (int)HttpStatusCode.OK)
            => new BaseResponse
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = true,
                Messages = new List<string>() { message }
            };

        public static BaseResponse Success(object data, List<string> messages, int statusCode = (int)HttpStatusCode.OK)
            => new BaseResponse
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = true,
                Messages = messages
            };

        public static BaseResponse Fail(object data, int statusCode = (int)HttpStatusCode.NotFound)
            => new BaseResponse
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = false,
                Messages = new List<string>()
            };

        public static BaseResponse Fail(object data, string message, int statusCode = (int)HttpStatusCode.NotFound)
            => new BaseResponse
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = false,
                Messages = new List<string> { message }
            };

        public static BaseResponse Fail(object data, List<string> messages, int statusCode = (int)HttpStatusCode.NotFound)
            => new BaseResponse
            {
                Data = data,
                StatusCode = statusCode,
                IsSuccess = false,
                Messages = messages
            };
    }

    public class BaseResponse<TData>
    {
        public TData Data { get; set; }
        public List<string> Messages { get; set; }
    }
}
