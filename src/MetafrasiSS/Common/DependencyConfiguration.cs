using Mapster;
using MapsterMapper;
using System.Reflection;

namespace MetafrasiSS.Common;

public static class DependencyConfiguration
{
    public static IServiceCollection AddMappings(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, ServiceMapper>();

        return services;
    }
}