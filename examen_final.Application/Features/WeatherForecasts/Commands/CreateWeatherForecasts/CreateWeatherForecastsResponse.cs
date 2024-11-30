namespace examen_final.Application.Features.WeatherForecasts.Commands.CreateWeatherForecasts;
public record CreateWeatherForecastsResponse(
    IEnumerable<Guid> Ids
);
