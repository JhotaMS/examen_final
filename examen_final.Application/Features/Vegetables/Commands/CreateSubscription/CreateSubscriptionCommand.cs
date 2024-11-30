using examen_final.Application.Messaging;
using examen_final.Domain.Enums;
using examen_final.Domain.Vegetables.Dtos;
using System.ComponentModel.DataAnnotations;

namespace examen_final.Application.Features.Vegetables.Commands.CreateSubscription;
public record CreateSubscriptionCommand(
    [Required] PackegeType PackegeId
    , [Required] TypePeriodicity PeriodicityId
    , IEnumerable<AdditionalVegetablesDto>? AdditionalVegetables
) : ICommand<CreateSubscriptionCommandResponse>;