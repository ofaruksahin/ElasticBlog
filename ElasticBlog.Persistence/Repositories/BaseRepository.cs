using ElasticBlog.Domain.Shared.Pagination;

namespace ElasticBlog.Persistence.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly ElasticBlogDbContext _dbContext;

        protected BaseRepository(ElasticBlogDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public IUnitOfWork UnitOfWork => _dbContext;

        public virtual async Task AddAsync(TEntity entity)
        {
            entity.SetCreatedDate();
            await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(List<TEntity> entities)
        {
            foreach (var item in entities)
                item.SetCreatedDate();
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
        }

        public virtual async void Delete(TEntity entity)
        {
            entity.Status = Domain.Shared.Enumerations.EnumRecordStatus.Passive;
            entity.SetLastModifiedDate();
            _dbContext.Set<TEntity>().Update(entity);
        }

        public virtual void DeleteRange(List<TEntity> entities)
        {
            foreach(var item in entities)
            {
                item.Status = Domain.Shared.Enumerations.EnumRecordStatus.Passive;
                item.SetLastModifiedDate();
            }

            _dbContext.Set<TEntity>().UpdateRange(entities);
        }

        public virtual async Task<List<TEntity>> GetAllActiveRecordsAsync()
        {
            return await _dbContext
                .Set<TEntity>()
                .Where(f => f.Status == Domain.Shared.Enumerations.EnumRecordStatus.Active)
                .ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAllRecordsAsync()
        {
            return await _dbContext
                .Set<TEntity>()
                .ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdActiveRecordAsync(int id)
        {
            return await _dbContext
                .Set<TEntity>()
                .FirstOrDefaultAsync(f => f.Id == id && f.Status == Domain.Shared.Enumerations.EnumRecordStatus.Active);
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext
                .Set<TEntity>()
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public virtual async Task<PaginatedResponse<TEntity>> PaginateActiveRecordsAsync(PaginationFilter filter)
        {
            var query = _dbContext.Set<TEntity>().Where(f => f.Status == Domain.Shared.Enumerations.EnumRecordStatus.Active);
            return await query.PaginateAsync(filter);
        }

        public virtual async Task<PaginatedResponse<TEntity>> PaginateAsync(PaginationFilter filter)
        {
            var query = _dbContext.Set<TEntity>().AsQueryable();
            return await query.PaginateAsync(filter);
        }

        public virtual void Update(TEntity entity)
        {
            entity.SetLastModifiedDate();
            _dbContext.Set<TEntity>().Update(entity);
        }

        public virtual void UpdateRange(List<TEntity> entities)
        {
            foreach (var item in entities)
                item.SetLastModifiedDate();
            _dbContext.Set<TEntity>().UpdateRange(entities);
        }
    }
}
