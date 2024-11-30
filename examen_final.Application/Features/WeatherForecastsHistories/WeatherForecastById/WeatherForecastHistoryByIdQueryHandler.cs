using examen_final.Application.Messaging;
using examen_final.Domain.Abstractions;
using examen_final.Domain.Ports;
using examen_final.Domain.WeatherForecasts.Dtos;
using examen_final.Domain.WeatherForecastsHistories;

namespace examen_final.Application.Features.WeatherForecastsHistories.WeatherForecastById;
internal sealed record class WeatherForecastHistoryByIdQueryHandler(
          WeatherForecastsHistoryService WeatherForecastsHistoryService
        , IJsonConfiguration JsonConfiguration
    ) : IQueryHandler<WeatherForecastHistoryByIdQuery, WeatherForecastHistoryByIdQueryResponse> {

    public async Task<Result<WeatherForecastHistoryByIdQueryResponse>> Handle(
          WeatherForecastHistoryByIdQuery request
        , CancellationToken cancellationToken
    ) {
        var history = await WeatherForecastsHistoryService.GetByAsync(
              request.Id
            , cancellationToken
        );

        var result = new WeatherForecastHistoryByIdQueryResponse(
            history.Id
            , JsonConfiguration.DeserializeObject<WeatherForecastByIdDto>( history.Proccess! )
            , history.CreatedDate
            , history.CreatedByUser
            , history.LastModifiedDate
            , history.LastModifiedByUser
        );

        return result;
    }
}
