namespace ElasticBlog.Application.Extensions
{
    public static class DbContextExtensions
    {
        public static void AddElasticBlogDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<ElasticBlogDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("MySQLConnectionString");
                ServerVersion serverVersion = ServerVersion.AutoDetect(connectionString);
                options.UseMySql(connectionString, serverVersion);
            });
        }
    }
}
