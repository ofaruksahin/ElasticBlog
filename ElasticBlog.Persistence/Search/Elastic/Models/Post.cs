using System;
namespace ElasticBlog.Persistence.Search.Elastic.Models
{
    public class Post
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

