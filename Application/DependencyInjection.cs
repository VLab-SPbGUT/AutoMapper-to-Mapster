using Application;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            MapsterConfiguration.Configure();

            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }
    }
}