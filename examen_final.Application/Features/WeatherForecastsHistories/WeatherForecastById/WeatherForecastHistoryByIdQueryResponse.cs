using examen_final.Domain.WeatherForecasts.Dtos;

namespace examen_final.Application.Features.WeatherForecastsHistories.WeatherForecastById;
public record WeatherForecastHistoryByIdQueryResponse(
      Guid Id
    , WeatherForecastByIdDto? Proccess
    , DateOnly? CreatedDate
    , string? CreatedByUser
    , DateOnly? LastModifiedDate
    , string? LastModifiedByUser
);
