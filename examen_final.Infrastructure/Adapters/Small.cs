using examen_final.Domain.Configurations;
using examen_final.Domain.Enums;
using examen_final.Domain.Ports;
using Microsoft.Extensions.Options;

namespace examen_final.Infrastructure.Adapters;
internal class Small : IPackegeIncrease {
    private readonly PackegeOptions packegeOptions;

    public Small( IOptions<PackegeOptions> packege ) {
        packegeOptions = packege.Value;
    }

    public PackegeType Packege => PackegeType.Small;
    public int Increase => packegeOptions.Small;
}
