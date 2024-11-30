namespace examen_final.Domain.Ports;
public interface IPercentageKilograms {
    public float BasePriceAddition { get; }
    int Percentage( int kiligrams );
}
