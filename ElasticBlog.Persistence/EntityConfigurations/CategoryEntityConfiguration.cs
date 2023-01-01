namespace ElasticBlog.Persistence.EntityConfigurations
{
    public class CategoryEntityConfiguration : BaseEntityConfiguration<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);

            builder
                .Property(f => f.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(f => f.Posts)
                .WithOne(f => f.Category)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            //builder.ToTable("categories");
        }
    }
}

