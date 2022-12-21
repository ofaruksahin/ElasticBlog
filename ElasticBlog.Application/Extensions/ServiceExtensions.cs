using ElasticBlog.Persistence.Search.Elastic;
using ElasticBlog.Persistence.Search.Elastic.Interfaces;
using ElasticBlog.Persistence.Search.Elastic.Models;
using Microsoft.Extensions.Options;

namespace ElasticBlog.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddElasticBlogServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IElasticLogger, ElasticLogger>();
            services.AddScoped(typeof(IElasticClient<>),typeof(ElasticClient<>));

            services.Configure<ElasticOptions>(configuration.GetSection("ElasticOptions"));
            services.AddScoped(sp =>
            {
                return sp.GetRequiredService<IOptions<ElasticOptions>>().Value;
            });
        }
    }
}
