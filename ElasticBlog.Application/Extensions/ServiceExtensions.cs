namespace ElasticBlog.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddElasticBlogServices(this IServiceCollection services)
        {
            services.AddScoped<IElasticLogger, ElasticLogger>();
        }
    }
}
