using ElasticBlog.Domain.ElasticModel;

namespace ElasticBlog.Domain.ValueObjects
{
    public class LogModel : BaseElasticModel
    {
        public DateTime RequestDate { get; set; }
        public string Path { get;private set; }
        public string Message { get;private set; }
        public LogLevel Level { get;private set; }

        public LogModel(DateTime requestDate,string path,string message)
        {
            RequestDate = requestDate;
            Path = path;
            Message = message;
        }

        public void SetLogLevel(LogLevel level)
        {
            Level = level;
        }
    }
}

