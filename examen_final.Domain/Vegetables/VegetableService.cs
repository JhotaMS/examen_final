using examen_final.Domain.DomainService;
using examen_final.Domain.Enums;
using examen_final.Domain.Ports;
using examen_final.Domain.Primitives;
using examen_final.Domain.Vegetables.Dtos;
using examen_final.Domain.Vegetables.Exceptions;

namespace examen_final.Domain.Vegetables;

[DomainService]
public sealed record class VegetableService {

    private readonly IEnumerable<IPackegeIncrease> _packegeIncreases;
    private readonly IPercentageKilograms _percentageKilograms;

    public VegetableService(
        IEnumerable<IPackegeIncrease> packegeIncreases
        , IPercentageKilograms percentageKilograms ) {
        _packegeIncreases = packegeIncreases;
        _percentageKilograms = percentageKilograms;
    }

    public IEnumerable<PackegeTypeDto> TypesVegetablesPackeges(
        CancellationToken cancellationToken = default
    ) {
        cancellationToken.ThrowIfCancellationRequested();

        foreach (PackegeType type in Enum.GetValues( typeof( PackegeType ) )) {
            yield return new PackegeTypeDto( (int)type, type.ToString() );
        }
    }

    public IEnumerable<PeriodDto> Periods(
        CancellationToken cancellationToken = default
    ) {
        cancellationToken.ThrowIfCancellationRequested();

        foreach (TypePeriodicity type in Enum.GetValues( typeof( TypePeriodicity ) )) {
            yield return new PeriodDto( (int)type, type.ToString() );
        }
    }

    public Vegetable CreateVegetableSubscription(
        PackegeType packege
        , TypePeriodicity periodicity
        , IEnumerable<AdditionalVegetablesDto>? additionalVegetables
        , CancellationToken cancellationToken = default
    ) {
        cancellationToken.ThrowIfCancellationRequested();

        float additionalPrice = 0F;
        List<AdditionalVegetablesWithPriceDto> list = [];

        IPackegeIncrease packegeIncrease = _packegeIncreases
            .FirstOrDefault( filter => filter.Packege.Equals( packege ) )
            ?? throw new PackageNotFoundException();

        var basePriceWithIncrease = Price.BasePriceWithIncrease( packegeIncrease.Increase );

        if (additionalVegetables is not null) {
            IEnumerable<AdditionalVegetablesWithPriceDto> additional = IncreaseByKg( additionalVegetables );
            additionalPrice = additional.Select( add => add.Price ).Sum();

            list.AddRange( additional );
        }

        var total = Price.Total( basePriceWithIncrease, additionalPrice, periodicity );
        return Vegetable.FACT.Create( total, packege, periodicity, list );
    }

    public IEnumerable<AdditionalVegetablesWithPriceDto> IncreaseByKg( IEnumerable<AdditionalVegetablesDto> additionalVegetables ) {
        Vegetable.FACT.ValidateAdditions( additionalVegetables.Count() );

        foreach (AdditionalVegetablesDto additional in additionalVegetables) {
            var percentage = _percentageKilograms.Percentage( additional.NecessaryQuantity );
            var price = Price.Additional( percentage );
            yield return new AdditionalVegetablesWithPriceDto(
                additional.Name
                , additional.NecessaryQuantity
                , price
            );
        }
    }
}
