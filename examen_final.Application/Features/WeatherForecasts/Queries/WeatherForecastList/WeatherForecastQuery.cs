using examen_final.Application.Messaging;

namespace examen_final.Application.Features.WeatherForecasts.Queries.WeatherForecastList;

public record WeatherForecastQuery(
) : IQuery<WeatherForecastResponse>;
