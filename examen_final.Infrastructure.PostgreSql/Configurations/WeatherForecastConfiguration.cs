using examen_final.Domain.Primitives;
using examen_final.Domain.WeatherForecasts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examen_final.Infrastructure.PostgreSql.Configurations;
internal sealed class WeatherForecastConfiguration
    : IEntityTypeConfiguration<WeatherForecast> {
    public void Configure( EntityTypeBuilder<WeatherForecast> builder ) {
        builder.ToTable( "WeatherForecasts" );
        builder.HasKey( property => property.Id );
        builder.Property( property => property.Date );
        builder.Property( property => property.TemperatureC );
        builder.Property( property => property.Summary );

        builder
            .Property( property => property.Temperature )
            .HasConversion(
                conversion => conversion.Value
                , value => new Temperature( value ) );

        builder.Property( property => property.Enabled );
    }
}
