using ElasticBlog.Domain.Models;
using ElasticBlog.Domain.Shared.Abstractions;
using ElasticBlog.Persistence.Shared;
using MediatR;

namespace ElasticBlog.Persistence
{
    public class ElasticBlogDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediator _mediator;

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ElasticBlogDbContext(DbContextOptions<ElasticBlogDbContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public ElasticBlogDbContext(DbContextOptions<ElasticBlogDbContext> options, IMediator mediator)
            : base(options)
        {
            _mediator = mediator;

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public async Task<bool> CompleteTransaction()
        {
            var result = await base.SaveChangesAsync() > 0;
            if (result)
                await _mediator.DispatchDomainEventAsync(this);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ElasticBlogDbContext).Assembly);
        }
    }
}
