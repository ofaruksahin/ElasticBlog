namespace ElasticBlog.Persistence.EntityConfigurations
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(f => f.Id);
            builder
                .Property(f => f.CreatedDate)
                .IsRequired()
                .HasDefaultValueSql("NOW(6)");
            builder
                .Property(f => f.LastModifiedDate)
                .HasDefaultValue(null);

            builder.Property(f => f.Status);
            builder.Ignore(f => f.DomainEvents);
        }
    }
}
