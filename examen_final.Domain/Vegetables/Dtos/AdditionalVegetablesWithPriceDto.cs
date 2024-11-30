namespace examen_final.Domain.Vegetables.Dtos;
public record AdditionalVegetablesWithPriceDto(
    string Name
    , int NecessaryQuantity
    , float Price
) : AdditionalVegetablesDto( Name, NecessaryQuantity );
