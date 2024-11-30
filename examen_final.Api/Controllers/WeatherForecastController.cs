using examen_final.Application.Features.WeatherForecasts.Commands.CreateWeatherForecasts;
using examen_final.Application.Features.WeatherForecasts.Queries.WeatherForecastList;
using examen_final.Application.Messaging;
using examen_final.Domain.Abstractions;
using examen_final.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace examen_final.Api.Controllers;

[Route( "api/v1/[controller]" )]
public class WeatherForecastController(
    ILogger<WeatherForecastController> logger,
    IDispatch dispatch
) : ControllerBase {

    [HttpGet()]
    public async Task<ActionResult<Result>> WeatherForecastAsync(
        CancellationToken cancellationToken
    ) {
        logger.LogInformation(
            "En la siguiente fecha {date} a las {time}, se llamo el endpoint {endpoint} de la clase {class}",
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "dd/MM/yyyy", provider: new CultureInfo( "es-CO" ) ),
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "hh:mm tt" ),
                "WeatherForecastAsync",
                nameof( WeatherForecastController )
        );

        return await dispatch.Send(
            new WeatherForecastQuery(),
            cancellationToken
        );
    }

    [HttpPost()]
    public async Task<ActionResult<Result>> CreateWeatherForecastAsync(
            CancellationToken cancellationToken
        ) {
        logger.LogInformation(
            "En la siguiente fecha {date} a las {time}, se llamo el endpoint {endpoint} de la clase {class}",
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "dd/MM/yyyy", provider: new CultureInfo( "es-CO" ) ),
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "hh:mm tt" ),
                "WeatherForecastAsync",
                nameof( WeatherForecastController )
        );

        return await dispatch.Send(
            new CreateWeatherForecastsCommand(),
            cancellationToken
        );
    }
}