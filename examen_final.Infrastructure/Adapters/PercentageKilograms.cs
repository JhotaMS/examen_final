using examen_final.Domain.Configurations;
using examen_final.Domain.Ports;
using Microsoft.Extensions.Options;

namespace examen_final.Infrastructure.Adapters;
internal sealed record class PercentageKilograms : IPercentageKilograms {

    private readonly PercentageKilogramsOptions _percentageKilogramsOptions;

    public PercentageKilograms(
        IOptions<PercentageKilogramsOptions> percentageKilogramsOptions
    ) {
        _percentageKilogramsOptions = percentageKilogramsOptions.Value;
    }

    public int Percentage( int kiligrams ) {
        int percentage = default;

        if (kiligrams == _percentageKilogramsOptions.BalancerOne.Kilograms) {
            percentage = _percentageKilogramsOptions.BalancerOne.Percentage;
        }
        else if (kiligrams == _percentageKilogramsOptions.BalancerTwo.Kilograms) {
            percentage = _percentageKilogramsOptions.BalancerTwo.Percentage;
        }
        else if (kiligrams >= _percentageKilogramsOptions.BalancerThree.Kilograms) {
            percentage = _percentageKilogramsOptions.BalancerThree.Percentage;
        }

        return percentage;
    }
}
