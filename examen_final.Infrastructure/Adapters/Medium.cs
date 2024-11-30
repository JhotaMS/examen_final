using examen_final.Domain.Configurations;
using examen_final.Domain.Enums;
using examen_final.Domain.Ports;
using Microsoft.Extensions.Options;

namespace examen_final.Infrastructure.Adapters;
internal sealed record class Medium : IPackegeIncrease {
    private readonly PackegeOptions packegeOptions;

    public Medium( IOptions<PackegeOptions> packege ) {
        packegeOptions = packege.Value;
    }

    public PackegeType Packege => PackegeType.Medium;
    public int Increase => packegeOptions.Medium;
}
