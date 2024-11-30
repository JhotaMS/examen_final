﻿using examen_final.Domain.DomainService;
using examen_final.Domain.Ports;

namespace examen_final.Domain.WeatherForecastsHistories;

[DomainService]
public class WeatherForecastsHistoryService(
        IUnitOfWork unitOfWork
) {
    public async Task<WeatherForecastsHistory> GetByAsync(
          Guid id 
        , CancellationToken cancellationToken
    ) {
        WeatherForecastsHistory result = await unitOfWork.Repository<WeatherForecastsHistory>().GetByAsync(
            history => history.Id.Equals( id )
            , disableTracking: false
            , cancellationToken
        );

        return result;
    }

    public async Task GenerateWeatherForecastsHistoryAsync(
        WeatherForecastsHistory weatherForecastsHistory,
        CancellationToken cancellationToken
    ) {
        ArgumentNullException.ThrowIfNull( nameof( weatherForecastsHistory ) );

        await unitOfWork.Repository<WeatherForecastsHistory>()
            .AddAsync( weatherForecastsHistory, cancellationToken );
    }
}
