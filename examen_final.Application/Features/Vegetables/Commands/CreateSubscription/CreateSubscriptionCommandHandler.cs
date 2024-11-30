using examen_final.Application.Messaging;
using examen_final.Domain.Abstractions;
using examen_final.Domain.Vegetables;

namespace examen_final.Application.Features.Vegetables.Commands.CreateSubscription;
internal sealed record class CreateSubscriptionCommandHandler(
    VegetableService VegetableService
) : ICommandHandler<CreateSubscriptionCommand, CreateSubscriptionCommandResponse> {
    public async Task<Result<CreateSubscriptionCommandResponse>> Handle(
        CreateSubscriptionCommand request
        , CancellationToken cancellationToken
    ) {

        ArgumentNullException.ThrowIfNullOrEmpty( nameof( request ) );
        var vegetable = VegetableService.CreateVegetableSubscription(
            request.PackegeId
            , request.PeriodicityId
            , request.AdditionalVegetables
            , cancellationToken
        );

        return new CreateSubscriptionCommandResponse( vegetable );
    }
}
