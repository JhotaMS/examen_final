using examen_final.Application.Messaging;
using examen_final.Domain.Abstractions;
using examen_final.Domain.Users;

namespace examen_final.Application.Features.Users.CreateUser;
internal sealed class UserCommandHandler( 
    UserService userService 
) : ICommandHandler<UserCommand, UserCommandResponse> {
    
    public async Task<Result<UserCommandResponse>> Handle( UserCommand request
        , CancellationToken cancellationToken 
    ) {
        Guid id = await userService
            .CreateUserAsync(
                User.Create(
                    request.FirstName
                    , request.SecondName
                    , request.SurName
                    , request.SecondSurName
                )
                , cancellationToken
            );

        return new UserCommandResponse( id );
    }
}
