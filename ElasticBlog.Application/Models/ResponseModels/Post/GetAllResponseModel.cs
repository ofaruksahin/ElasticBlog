namespace ElasticBlog.Application.Models.ResponseModels.Post
{
    public class GetAllPostResponseModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
    }
}

