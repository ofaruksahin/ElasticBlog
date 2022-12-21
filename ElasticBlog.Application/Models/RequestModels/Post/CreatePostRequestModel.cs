namespace ElasticBlog.Application.Models.RequestModels.Post
{
    public class CreatePostRequestModel
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public List<TagRequestModel> Tags { get; set; }

        public CreatePostRequestModel()
        {
            Tags = new List<TagRequestModel>();
        }
    }
}

