using System;
namespace ElasticBlog.Domain.ElasticModel
{
    public class Post : BaseElasticModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }

        public Post()
        {
            Tags = new List<string>();
        }
    }
}

