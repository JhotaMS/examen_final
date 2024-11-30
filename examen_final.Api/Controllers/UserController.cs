using examen_final.Application.Features.Users.CreateUser;
using examen_final.Application.Messaging;
using examen_final.Domain.Abstractions;
using examen_final.Domain.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace examen_final.Api.Controllers;

[Route( "api/v1/[controller]" )]
public class UserController(
    ILogger<UserController> logger,
    IDispatch dispatch
) : ControllerBase {

    [HttpPost()]
    public async Task<ActionResult<Result>> CreateWeatherForecastAsync(
        [FromBody] UserCommand request,
        CancellationToken cancellationToken
    ) {
        logger.LogInformation(
            "En la siguiente fecha {date} a las {time}, se llamo el endpoint {endpoint} de la clase {class}",
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "dd/MM/yyyy", provider: new CultureInfo( "es-CO" ) ),
                DateTime.Now.ZoneByIdPacificStandardTime().ToString( "hh:mm tt" ),
                "UserController",
                nameof( UserController )
        );

        return await dispatch.Send(
            request,
            cancellationToken
        );
    }
}
