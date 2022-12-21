using ElasticBlog.Domain.ValueObjects;

namespace ElasticBlog.Domain.IServices
{
    public interface IElasticLogger
    {
        Task LogWarning(LogModel logModel);
        Task LogInformation(LogModel logModel);
        Task LogCritical(LogModel logModel);
        Task LogException(LogModel logModel);
    }
}
