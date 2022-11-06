namespace ElasticBlog.Domain.Shared.Abstractions
{
    public interface IUnitOfWork
    {
        Task<bool> CompleteTransaction();
    }
}
