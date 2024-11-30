using examen_final.Domain.Vegetables.Dtos;

namespace examen_final.Application.Features.Vegetables.Queries.TypesVegetablesPackeges;
public record TypesVegetablesPackegesQueryResponse(
    IEnumerable<PackegeTypeDto> PackegeTypes
);
