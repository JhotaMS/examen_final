using examen_final.Application.Messaging;
using examen_final.Domain.Abstractions;
using examen_final.Domain.WeatherForecasts;
using examen_final.Domain.WeatherForecasts.Dtos;

namespace examen_final.Application.Features.WeatherForecasts.Queries.WeatherForecastList;

internal sealed class WeatherForecastQueryHandler(
        WeatherForecastService forecastService
    ) : IQueryHandler<WeatherForecastQuery, WeatherForecastResponse> {

    public async Task<Result<WeatherForecastResponse>> Handle( WeatherForecastQuery request
        , CancellationToken cancellationToken 
    ) {

        IEnumerable<WeatherForecastDto> weatherForecasts = await forecastService.WeatherForecastsAsync();
        return new WeatherForecastResponse( weatherForecasts );
    }
}
