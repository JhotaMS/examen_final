using examen_final.Application.Messaging;
using examen_final.Domain.Abstractions;
using examen_final.Domain.Vegetables;

namespace examen_final.Application.Features.Vegetables.Queries.Periods;
internal sealed record class PeriodsQueryHandler(
    VegetableService VegetableService
) : IQueryHandler<PeriodsQuery, PeriodsQueryResponse> {
    public async Task<Result<PeriodsQueryResponse>> Handle(
        PeriodsQuery request
        , CancellationToken cancellationToken
    ) {
        await Task.Yield();

        return new PeriodsQueryResponse(
            VegetableService.Periods( cancellationToken )
        );
    }
}
