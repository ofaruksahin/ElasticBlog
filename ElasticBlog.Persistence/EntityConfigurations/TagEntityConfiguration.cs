namespace ElasticBlog.Persistence.EntityConfigurations
{
    public class TagEntityConfiguration : BaseEntityConfiguration<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);

            builder
                .Property(f => f.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasOne(f => f.Post)
                .WithMany(f => f.Tags)
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.ToTable("tags");
        }
    }
}

