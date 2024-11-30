using examen_final.Application.Messaging;
using examen_final.Domain.Abstractions;
using examen_final.Domain.Vegetables;

namespace examen_final.Application.Features.Vegetables.Queries.TypesVegetablesPackeges;
internal sealed record class TypesVegetablesPackegesQueryHandler(
    VegetableService VegetableService
) : IQueryHandler<TypesVegetablesPackegesQuery, TypesVegetablesPackegesQueryResponse> {
    public async Task<Result<TypesVegetablesPackegesQueryResponse>> Handle(
        TypesVegetablesPackegesQuery request
        , CancellationToken cancellationToken
    ) {
        await Task.Yield();

        return new TypesVegetablesPackegesQueryResponse(
            VegetableService.TypesVegetablesPackeges( cancellationToken )
        );
    }
}
