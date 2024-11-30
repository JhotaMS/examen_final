using examen_final.Domain.Enums;

namespace examen_final.Domain.Ports;
public interface IPackegeIncrease {
    int Increase { get; }
    PackegeType Packege { get; }
}
