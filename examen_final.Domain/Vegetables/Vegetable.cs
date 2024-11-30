using examen_final.Domain.Enums;
using examen_final.Domain.Vegetables.Dtos;
using examen_final.Domain.Vegetables.Exceptions;

namespace examen_final.Domain.Vegetables;
public sealed record class Vegetable {
    private Vegetable( 
        PackegeType packege
        , TypePeriodicity periodicity
        , IEnumerable<AdditionalVegetablesWithPriceDto> additionalVegetables
        , float totalPrice 
    ) {
        Packege = packege;
        Periodicity = periodicity;
        AdditionalVegetables = additionalVegetables;
        TotalPrice = totalPrice;
    }

    public PackegeType Packege { get; private set; }
    public TypePeriodicity Periodicity { get; private set; }
    public IEnumerable<AdditionalVegetablesWithPriceDto> AdditionalVegetables { get; private set; } = [];
    public float TotalPrice { get; private set; }

    public static class FACT {
        private const int MAXIMUM_QUANTITY = 5;
        public static Vegetable Create(
            float totalPrice
            , PackegeType packege
            , TypePeriodicity periodicity
            , IEnumerable<AdditionalVegetablesWithPriceDto> additionalVegetables
        ) => new (
            packege
            , periodicity
            , additionalVegetables
            , totalPrice
        );

        public static void ValidateAdditions( int count ) {
            if ( count > MAXIMUM_QUANTITY) {
                throw new MaximumLimitException();
            }
        }
    }
}
