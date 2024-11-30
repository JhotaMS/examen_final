using examen_final.Domain.WeatherForecasts.Dtos;

namespace examen_final.Application.Features.WeatherForecasts.Queries.WeatherForecastList;

public record WeatherForecastResponse(
    IEnumerable<WeatherForecastDto> WeatherForecasts
);
