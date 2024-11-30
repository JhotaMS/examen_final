using examen_final.Domain.Enums;

namespace examen_final.Domain.Primitives;
public record Price {

    private const float BASE_PRICE = 15000F;
    private const int DIVIDEND_VALUE = 100;
    private const int MONTHLY = 4;

    public Price( float value ) {
        Value = value;
    }
    public float Value { get; private set; }

    public static float BasePriceWithIncrease( int increasePercentage ) {
        return BASE_PRICE + (BASE_PRICE * increasePercentage / DIVIDEND_VALUE);
    }

    public static float Additional( float basePriceAddition, int additionalPercentage ) {
        return basePriceAddition * additionalPercentage / DIVIDEND_VALUE;
    }

    public static float Total( float price, float additional, TypePeriodicity periodicity ) {

        price = price + additional;
        if (periodicity is TypePeriodicity.Monthly) 
            price = price * MONTHLY;

        return price;
    }
}
