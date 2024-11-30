using examen_final.Application.Features.Vegetables.Commands.CreateSubscription;
using examen_final.Application.Features.Vegetables.Queries.Periods;
using examen_final.Application.Features.Vegetables.Queries.TypesVegetablesPackeges;
using examen_final.Application.Messaging;
using examen_final.Domain.Abstractions;
using examen_final.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace examen_final.Api.Controllers;

[Route( "api/v1/[controller]" )]
public class ShoppingSubscriptions(
    ILogger<ShoppingSubscriptions> logger,
    IDispatch dispatch
) : ControllerBase {

    private const string TYPES_VEGETABLES_PACKEGES = "types/VegetablePackeges";
    private const string TYPES_PERIOD = "types/Period";
    private const string VEGETABLE = "vegetables";

    [HttpGet( TYPES_VEGETABLES_PACKEGES )]
    public async Task<ActionResult<Result>> TypesVegetablesPackegesAsync(
        CancellationToken cancellationToken
    ) {
        logger.LogInformation(
            "En la siguiente fecha {date} a las {time}, se llamo el endpoint {endpoint} de la clase {class}",
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "dd/MM/yyyy", provider: new CultureInfo( "es-CO" ) ),
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "hh:mm tt" ),
                TYPES_VEGETABLES_PACKEGES,
                nameof( ShoppingSubscriptions )
        );

        var result = await dispatch.Send(
            new TypesVegetablesPackegesQuery(),
            cancellationToken
        ).ConfigureAwait( false );

        if (result.IsFailure) {
            return Unauthorized( result.Error );
        }

        return Ok( result.Value.PackegeTypes );
    }

    [HttpGet( TYPES_PERIOD )]
    public async Task<ActionResult<Result>> TypesPeriodAsync(
        CancellationToken cancellationToken
    ) {
        logger.LogInformation(
            "En la siguiente fecha {date} a las {time}, se llamo el endpoint {endpoint} de la clase {class}",
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "dd/MM/yyyy", provider: new CultureInfo( "es-CO" ) ),
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "hh:mm tt" ),
                TYPES_PERIOD,
                nameof( ShoppingSubscriptions )
        );

        var result = await dispatch.Send(
            new PeriodsQuery(),
            cancellationToken
        ).ConfigureAwait( false );

        if (result.IsFailure) {
            return Unauthorized( result.Error );
        }

        return Ok( result.Value.Periods );
    }

    [HttpPost( VEGETABLE )]
    public async Task<ActionResult<Result>> CreateWeatherForecastAsync(
        [FromBody] CreateSubscriptionCommand request,
        CancellationToken cancellationToken
    ) {
        logger.LogInformation(
            "En la siguiente fecha {date} a las {time}, se llamo el endpoint {endpoint} de la clase {class}",
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "dd/MM/yyyy", provider: new CultureInfo( "es-CO" ) ),
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "hh:mm tt" ),
                VEGETABLE,
        nameof( ShoppingSubscriptions )
        );

        var result = await dispatch
            .Send( 
                request
                , cancellationToken 
            ).ConfigureAwait( false );

        if (result.IsFailure) {
            return Unauthorized( result.Error );
        }

        return Ok( result.Value );
    }
}
