namespace ElasticBlog.Application.Extensions
{
    public static class FluentValidationExtensions
    {
        public static void AddValidators(this IServiceCollection services)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (string.IsNullOrEmpty(type.Namespace))
                        continue;

                    if (!type.Namespace.StartsWith("ElasticBlog"))
                        continue;

                    var interfaces = type.GetInterfaces().ToList();

                    if (!interfaces.Any())
                        continue;

                    var contractType = interfaces.FirstOrDefault(f => f.Name.Contains(nameof(IValidator)) && f.IsGenericType);

                    if (contractType == null)
                        continue;

                    services.AddScoped(contractType, type);
                }
            }
        }
    }
}
