namespace ElasticBlog.Domain.Shared.Abstractions
{
    public interface IRepository<TEntity>
        where TEntity : BaseEntity
    {
        Task<List<TEntity>> GetAllActiveRecordsAsync();
        Task<List<TEntity>> GetAllRecordsAsync();
        Task<TEntity> GetByIdActiveRecordAsync(int id);
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
        void Delete(TEntity entity);
        void DeleteRange(List<TEntity> entities);
        Task<PaginatedResponse<TEntity>> PaginateAsync(PaginationFilter filter);
        Task<PaginatedResponse<TEntity>> PaginateActiveRecordsAsync(PaginationFilter filter);

        IUnitOfWork UnitOfWork { get; }
    }
}
