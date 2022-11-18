namespace ElasticBlog.Persistence.EntityConfigurations
{
    public class PostEntityConfiguration : BaseEntityConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            base.Configure(builder);

            builder
                .Property(f => f.CategoryId)
                .IsRequired();

            builder
                .Property(f => f.Title)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(f => f.Content)
                .HasColumnType("TEXT")
                .IsRequired();

            builder.HasOne(f => f.Category)
                .WithMany(f => f.Posts)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .HasMany(f => f.Tags)
                .WithOne(f => f.Post)
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.ToTable("posts");
        }
    }
}

