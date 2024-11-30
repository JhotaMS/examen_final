using examen_final.Domain.Ports;
using examen_final.Infrastructure.Adapters;
using Microsoft.Extensions.DependencyInjection;

namespace examen_final.Infrastructure.Extensions;
public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure( this IServiceCollection services ) {

        services.AddScoped<IPackegeIncrease, Small>();
        services.AddScoped<IPackegeIncrease, Large>();
        services.AddScoped<IPackegeIncrease, Medium>();
        services.AddScoped<IPercentageKilograms, PercentageKilograms>();
        return services;
    }
}
