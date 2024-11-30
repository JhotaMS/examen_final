using examen_final.Domain.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace examen_final.Application.Extensions;
public static class DependencyInjectionOptions {
    public static IServiceCollection AddOptions(
        this IServiceCollection services,
        IConfiguration configuration
    ) {
        services.Configure<PercentageKilogramsOptions>(
            options => configuration
                .GetSection( PercentageKilogramsOptions.Fact.SECTION_NAME )
                .Bind( options )
        );

        services.Configure<PackegeOptions>(
            options => configuration
                .GetSection( PackegeOptions.Fact.SECTION_NAME )
                .Bind( options )
        );

        return services;
    }
}
