using examen_final.Application.Messaging;

namespace examen_final.Application.Features.WeatherForecasts.Commands.CreateWeatherForecasts;
public record CreateWeatherForecastsCommand(
    ) : ICommand<CreateWeatherForecastsResponse>;
