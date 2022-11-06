namespace ElasticBlog.Domain.Shared.Abstractions
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
