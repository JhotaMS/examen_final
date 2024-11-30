using examen_final.Application.Messaging;
using System.ComponentModel.DataAnnotations;

namespace examen_final.Application.Features.Users.CreateUser;
public record UserCommand(
    [Required] string FirstName
    , string? SecondName
    , [Required] string SurName
    , string? SecondSurName
    ) : ICommand<UserCommandResponse>;
