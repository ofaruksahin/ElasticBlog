using ElasticBlog.Application.Pipelines;

namespace ElasticBlog.Application.Extensions
{
    public static class PipelineExtensions
    {
        public static void AddPipelines(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ElasticLoggerPipeline<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationPipeline<,>));
        }
    }
}
