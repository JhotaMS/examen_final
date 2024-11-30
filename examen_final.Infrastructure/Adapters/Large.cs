using examen_final.Domain.Configurations;
using examen_final.Domain.Enums;
using examen_final.Domain.Ports;
using Microsoft.Extensions.Options;

namespace examen_final.Infrastructure.Adapters; 
internal sealed record class Large : IPackegeIncrease {

    private readonly PackegeOptions packegeOptions;

    public Large( IOptions<PackegeOptions> packege ) {
        packegeOptions = packege.Value;
    }

    public PackegeType Packege => PackegeType.Large;
    public int Increase => packegeOptions.Large;
}
